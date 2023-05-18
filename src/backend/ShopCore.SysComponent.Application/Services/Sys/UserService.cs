using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Sms;
using ShopCore.Domain.Dto.Sys.User;
using ShopCore.Domain.Dto.Sys.UserProfile;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.SysComponent.Application.Services.Sys;

/// <inheritdoc cref="IUserService" />
public sealed class UserService : RepositoryService<Sys_User, IUserService>, IUserService
{
    private readonly Expression<Func<Sys_User, Sys_User>> _selectUserFields = a => new Sys_User {
        Id          = a.Id
      , Positions   = a.Positions
      , Avatar      = a.Avatar
      , Email       = a.Email
      , Mobile      = a.Mobile
      , Enabled     = a.Enabled
      , UserName    = a.UserName
      , Version     = a.Version
      , CreatedTime = a.CreatedTime
      , Dept        = new Sys_Dept { Id = a.Dept.Id, Name = a.Dept.Name }
      , Roles       = a.Roles
    };

    private readonly ISmsService _smsService;

    private readonly IUserProfileService _userProfileService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserService" /> class.
    /// </summary>
    public UserService(Repository<Sys_User> rpo, IUserProfileService userProfileService, ISmsService smsService) //
        : base(rpo)
    {
        _userProfileService = userProfileService;
        _smsService         = smsService;
    }

    /// <summary>
    ///     批量删除用户
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
    ///     检查手机号是否可用
    /// </summary>
    public async Task<bool> CheckMobileAvailableAsync(CheckMobileAvailableReq req)
    {
        return !await Rpo.Select.Where(a => a.Mobile == req.Mobile).AnyAsync();
    }

    /// <summary>
    ///     检查用户名是否可用
    /// </summary>
    public async Task<bool> CheckUserNameAvailableAsync(CheckUserNameAvailableReq req)
    {
        return !await Rpo.Select.Where(a => a.UserName == req.UserName).AnyAsync();
    }

    /// <summary>
    ///     创建用户
    /// </summary>
    public async Task<QueryUserRsp> CreateAsync(CreateUserReq req)
    {
        await CreateUpdateCheckAsync(req);

        // 主表
        var entity = req.Adapt<Sys_User>();
        var dbUser = await Rpo.InsertAsync(entity);

        // 分表
        await Rpo.SaveManyAsync(entity, nameof(entity.Roles));
        await Rpo.SaveManyAsync(entity, nameof(entity.Positions));

        // 档案表
        _ = await _userProfileService.CreateAsync(req.Profile with { Id = dbUser.Id });
        var ret = await QueryAsync(new QueryReq<QueryUserReq> { Filter = new QueryUserReq { Id = dbUser.Id } });
        return ret.First();
    }

    /// <summary>
    ///     删除用户
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<int> DeleteAsync(DelReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     判断用户是否存在
    /// </summary>
    public async Task<bool> ExistAsync(QueryReq<QueryUserReq> req)
    {
        return await (await QueryInternalAsync(req)).AnyAsync();
    }

    /// <summary>
    ///     获取单个用户
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryUserRsp> GetAsync(QueryUserReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个用户（带更新锁）
    /// </summary>
    public async Task<QueryUserRsp> GetForUpdateAsync(QueryUserReq req)
    {
        // ReSharper disable once MethodHasAsyncOverload
        return (await QueryInternal(new QueryReq<QueryUserReq> { Filter = req }).ForUpdate().ToOneAsync())
            .Adapt<QueryUserRsp>();
    }

    /// <summary>
    ///     分页查询用户
    /// </summary>
    public async Task<PagedQueryRsp<QueryUserRsp>> PagedQueryAsync(PagedQueryReq<QueryUserReq> req)
    {
        var list = await (await QueryInternalAsync(req)).Page(req.Page, req.PageSize)
                                                        .Count(out var total)
                                                        .ToListAsync(_selectUserFields);
        return new PagedQueryRsp<QueryUserRsp>(req.Page, req.PageSize, total, list.Adapt<IEnumerable<QueryUserRsp>>());
    }

    /// <summary>
    ///     密码登录
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">用户名或密码错误</exception>
    public async Task<LoginRsp> PwdLoginAsync(PwdLoginReq req)
    {
        var pwd = req.Password.Pwd().Guid();

        Sys_User dbUser;
        #pragma warning disable IDE0045
        if (new MobileAttribute().IsValid(req.Account)) {
            #pragma warning restore IDE0045
            dbUser = await Rpo.GetAsync(a => a.Mobile == req.Account && a.Password == pwd);
        }
        else {
            dbUser = new EmailAddressAttribute().IsValid(req.Account)
                ? await Rpo.GetAsync(a => a.Email    == req.Account && a.Password == pwd)
                : await Rpo.GetAsync(a => a.UserName == req.Account && a.Password == pwd);
        }

        return dbUser is null ? throw new ShopCoreInvalidOperationException(Ln.用户名或密码错误) : LoginInternal(dbUser);
    }

    /// <summary>
    ///     查询用户
    /// </summary>
    public async Task<IEnumerable<QueryUserRsp>> QueryAsync(QueryReq<QueryUserReq> req)
    {
        var list = await (await QueryInternalAsync(req)).Take(req.Count).ToListAsync(_selectUserFields);
        return list.Adapt<IEnumerable<QueryUserRsp>>();
    }

    /// <summary>
    ///     查询用户档案
    /// </summary>
    public Task<IEnumerable<QueryUserProfileRsp>> QueryProfileAsync(QueryReq<QueryUserProfileReq> req)
    {
        return _userProfileService.QueryAsync(req);
    }

    /// <summary>
    ///     注册用户
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">短信验证码不正确</exception>
    public async Task<QueryUserRsp> RegisterAsync(RegisterReq req)
    {
        if (!await _smsService.VerifySmsCodeAsync(req.VerifySmsCodeReq)) {
            throw new ShopCoreInvalidOperationException(Ln.短信验证码不正确);
        }

        var createReq = req.Adapt<CreateUserReq>();
        return await CreateAsync(createReq);
    }

    /// <summary>
    ///     重设密码
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">短信验证码不正确</exception>
    /// <exception cref="ShopCoreInvalidOperationException">用户不存在</exception>
    public async Task ResetPasswordAsync(ResetPasswordReq req)
    {
        if (!await _smsService.VerifySmsCodeAsync(req.VerifySmsCodeReq)) {
            throw new ShopCoreInvalidOperationException(Ln.短信验证码不正确);
        }

        var dbUser = await Rpo.GetAsync(a => a.Mobile == req.VerifySmsCodeReq.DestMobile);
        if (dbUser is null) {
            throw new ShopCoreInvalidOperationException(Ln.用户不存在);
        }

        dbUser.Password = req.PasswordText.Pwd().Guid();

        _ = await Rpo.UpdateDiy.SetSource(dbUser).ExecuteAffrowsAsync();
    }

    /// <summary>
    ///     短信登录
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">短信验证码不正确</exception>
    /// <exception cref="ShopCoreInvalidOperationException">用户不存在</exception>
    public async Task<LoginRsp> SmsLoginAsync(SmsLoginReq req)
    {
        if (!await _smsService.VerifySmsCodeAsync(req.Adapt<VerifySmsCodeReq>())) {
            throw new ShopCoreInvalidOperationException(Ln.短信验证码不正确);
        }

        var dbUser = await Rpo.GetAsync(a => a.Mobile == req.DestMobile);
        return dbUser is null ? throw new ShopCoreInvalidOperationException(Ln.用户不存在) : LoginInternal(dbUser);
    }

    /// <summary>
    ///     更新用户
    /// </summary>
    public async Task<QueryUserRsp> UpdateAsync(UpdateUserReq req)
    {
        await CreateUpdateCheckAsync(req);

        // 主表
        var entity = req.Adapt<Sys_User>();
        _ = await Rpo.UpdateDiy.SetSource(entity).IgnoreColumns(a => new { a.Password, a.Token }).ExecuteAffrowsAsync();

        // 档案表
        _ = await _userProfileService.UpdateAsync(req.Profile);

        // 分表
        await Rpo.SaveManyAsync(entity, nameof(entity.Roles));
        await Rpo.SaveManyAsync(entity, nameof(entity.Positions));

        var ret = await QueryAsync(new QueryReq<QueryUserReq> { Filter = new QueryUserReq { Id = req.Id } });
        return ret.First();
    }

    /// <summary>
    ///     单体更新
    /// </summary>
    public Task UpdateSingleAsync(UpdateUserReq req)
    {
        return Rpo.UpdateAsync(req);
    }

    /// <summary>
    ///     当前用户信息
    /// </summary>
    public async Task<QueryUserRsp> UserInfoAsync()
    {
        var dbUser = await Rpo.Where(a => a.Token == UserToken.Token && a.Enabled)
                              .Include(a => a.Dept)
                              .Include(a => a.Member)
                              .IncludeMany( //
                                  a => a.Roles
                                , then => then.IncludeMany(a => a.Menus)
                                              .IncludeMany(a => a.Depts)
                                              .IncludeMany(a => a.Apis))
                              .ToOneAsync();
        return dbUser.Adapt<QueryUserRsp>();
    }

    private static LoginRsp LoginInternal(IFieldEnabled dbUser)
    {
        if (!dbUser.Enabled) {
            throw new ShopCoreInvalidOperationException(Ln.请联系管理员激活账号);
        }

        var tokenPayload
            = new Dictionary<string, object> { { nameof(ContextUserToken), dbUser.Adapt<ContextUserToken>() } };

        var accessToken = JWTEncryption.Encrypt(tokenPayload);
        return new LoginRsp {
                                AccessToken  = accessToken
                              , RefreshToken = JWTEncryption.GenerateRefreshToken(accessToken)
                            };
    }

    private async Task CreateUpdateCheckAsync(CreateUserReq req)
    {
        // 检查角色是否存在
        var roles = await Rpo.Orm.Select<Sys_Role>()
                             .ForUpdate()
                             .Where(a => req.RoleIds.Contains(a.Id))
                             .ToListAsync(a => a.Id);
        if (roles.Count != req.RoleIds.Count) {
            throw new ShopCoreInvalidOperationException(Ln.角色不存在);
        }

        // 检查岗位是否存在
        var positions = await Rpo.Orm.Select<Sys_Position>()
                                 .ForUpdate()
                                 .Where(a => req.PositionIds.Contains(a.Id))
                                 .ToListAsync(a => a.Id);
        if (positions.Count != req.PositionIds.Count) {
            throw new ShopCoreInvalidOperationException(Ln.岗位不存在);
        }

        // 检查部门是否存在
        var dept = await Rpo.Orm.Select<Sys_Dept>().ForUpdate().Where(a => req.DeptId == a.Id).ToListAsync(a => a.Id);

        if (dept.Count != 1) {
            throw new ShopCoreInvalidOperationException(Ln.部门不存在);
        }
    }

    private ISelect<Sys_User> QueryInternal(QueryReq<QueryUserReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    private async Task<ISelect<Sys_User>> QueryInternalAsync(QueryReq<QueryUserReq> req)
    {
        IEnumerable<long> deptIds = null;
        if (req.Filter?.DeptId > 0) {
            deptIds = await Rpo.Orm.Select<Sys_Dept>()
                               .Where(a => a.Id == req.Filter.DeptId)
                               .AsTreeCte()
                               .ToListAsync(a => a.Id);
        }

        var ret = Rpo.Select.Include(a => a.Dept)
                     .IncludeMany(a => a.Roles.Select(b => new Sys_Role { Id         = b.Id, Name = b.Name }))
                     .IncludeMany(a => a.Positions.Select(b => new Sys_Position { Id = b.Id, Name = b.Name }))
                     .WhereDynamicFilter(req.DynamicFilter)
                     .WhereIf(deptIds is not null, a => deptIds.Contains(a.DeptId))
                     .WhereIf( //
                         req.Filter?.Id > 0, a => a.Id == req.Filter.Id)
                     .WhereIf( //
                         req.Filter?.RoleId > 0, a => a.Roles.Any(b => b.Id == req.Filter.RoleId))
                     .WhereIf( //
                         req.Filter?.PositionId > 0, a => a.Positions.Any(b => b.Id == req.Filter.PositionId))
                     .WhereIf( //
                         req.Keywords?.Length > 0
                       , a => a.UserName.Contains(req.Keywords) || a.Id == req.Keywords.Int64Try(0) ||
                              a.Mobile                                  == req.Keywords)
                     .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending);

        if (!req.Prop?.Equals(nameof(req.Filter.CreatedTime), StringComparison.OrdinalIgnoreCase) ?? true) {
            ret = ret.OrderByDescending(a => a.CreatedTime);
        }

        return ret;
    }
}