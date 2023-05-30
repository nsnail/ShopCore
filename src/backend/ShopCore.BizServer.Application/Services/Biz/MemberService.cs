using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Sms;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberService" />
public sealed class MemberService : RepositoryService<Biz_Member, IMemberService>, IMemberService
{
    private readonly IConfigService _configService;
    private readonly IUserService   _userService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberService" /> class.
    /// </summary>
    public MemberService(Repository<Biz_Member> rpo, IConfigService configService, IUserService userService) //
        : base(rpo)
    {
        _configService = configService;
        _userService   = userService;
    }

    /// <summary>
    ///     批量删除会员
    /// </summary>
    public async Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        var sum = 0;
        foreach (var item in req.Items) {
            sum += await DeleteAsync(item);
        }

        return sum;
    }

    /// <summary>
    ///     创建会员
    /// </summary>
    public Task<QueryMemberRsp> CreateAsync(CreateMemberReq req)
    {
        var regReq = req.Adapt<RegisterMemberReq>();

        // 免除短信验证
        regReq.SysUser.VerifySmsCodeReq = new VerifySmsCodeReq { Code = Global.SecretKey, DestMobile = req.SysUser.Mobile };

        // 走注册流程
        return RegisterAsync(regReq);
    }

    /// <summary>
    ///     删除会员
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryMemberReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个会员
    /// </summary>
    public async Task<QueryMemberRsp> GetAsync(QueryMemberReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryMemberReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryMemberRsp>();
    }

    /// <summary>
    ///     分页查询会员
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberRsp>(req.Page, req.PageSize, total, list.Adapt<IEnumerable<QueryMemberRsp>>());
    }

    /// <summary>
    ///     查询会员
    /// </summary>
    public async Task<IEnumerable<QueryMemberRsp>> QueryAsync(QueryReq<QueryMemberReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberRsp>>();
    }

    /// <summary>
    ///     会员注册
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">手机号已被使用</exception>
    public async Task<QueryMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        // 获取配置信息
        var config = await _configService.GetLatestConfigAsync();

        // 创建系统用户
        var sysUser = await _userService.RegisterAsync(req.SysUser //
                                                           with {
                                                                    DeptId = config.UserRegisterDeptId
                                                                  , PositionIds = new[] { config.UserRegisterPosId }
                                                                  , RoleIds = new[] { config.UserRegisterRoleId }
                                                                  , Enabled = !config.UserRegisterConfirm
                                                                });

        // 创建会员
        var member = await Rpo.InsertAsync(sysUser.Adapt<CreateMemberReq>());
        return member.Adapt<QueryMemberRsp>() with { SysUser = sysUser };
    }

    /// <summary>
    ///     更新会员
    /// </summary>
    public async Task<QueryMemberRsp> UpdateAsync(UpdateMemberReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberRsp>();
    }

    private ISelect<Biz_Member> QueryInternal(QueryReq<QueryMemberReq> req)
    {
        return Rpo.Select.Include(a => a.SysUser)
                  .WhereDynamicFilter(req.DynamicFilter)
                  .WhereIf( //
                      req.Filter?.Id                      > 0, a => a.Id == req.Filter.Id)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryMemberRsp> UpdateForSqliteAsync(Biz_Member req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await QueryInternal(new QueryReq<QueryMemberReq> { Filter = new QueryMemberReq { Id = req.Id } }).ToOneAsync();
        return ret.Adapt<QueryMemberRsp>();
    }
}