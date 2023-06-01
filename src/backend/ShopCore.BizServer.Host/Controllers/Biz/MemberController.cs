using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.User;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberController : ControllerBase<IMemberService>, IMemberModule
{
    private readonly IUserService _userService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberController" /> class.
    /// </summary>
    public MemberController(IMemberService service, IUserService userService) //
        : base(service)
    {
        _userService = userService;
    }

    /// <summary>
    ///     批量删除会员
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员
    /// </summary>
    [Transaction]
    public Task<QueryMemberRsp> CreateAsync(CreateMemberReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员
    /// </summary>
    [NonAction]
    public Task<QueryMemberRsp> GetAsync(QueryMemberReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     当前会员信息
    /// </summary>
    public Task<QueryMemberRsp> MemberInfoAsync()
    {
        return Service.MemberInfoAsync();
    }

    /// <summary>
    ///     分页查询会员
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员
    /// </summary>
    public Task<IEnumerable<QueryMemberRsp>> QueryAsync(QueryReq<QueryMemberReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     会员注册
    /// </summary>
    [AllowAnonymous]
    [Transaction]
    public async Task<QueryMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        var ret = await Service.RegisterAsync(req);
        var loginRsp = await _userService.LoginByPwdAsync(new LoginByPwdReq {
                                                                                Account  = req.SysUser.UserName
                                                                              , Password = req.SysUser.PasswordText
                                                                            });
        loginRsp.SetToRspHeader();
        return ret;
    }

    /// <summary>
    ///     更新会员
    /// </summary>
    [Transaction]
    public Task<QueryMemberRsp> UpdateAsync(UpdateMemberReq req)
    {
        return Service.UpdateAsync(req);
    }
}