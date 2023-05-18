using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.User;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberController : ControllerBase<IMemberService>, IMemberModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberController" /> class.
    /// </summary>
    public MemberController(IMemberService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     检查手机号是否可用
    /// </summary>
    [AllowAnonymous]
    public Task<bool> CheckMobileAvailableAsync(CheckMobileAvailableReq req)
    {
        return Service.CheckMobileAvailableAsync(req);
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
    ///     初始化登录密码
    /// </summary>
    [Transaction]
    public Task InitLoginPwdAsync(InitLoginPwdReq req)
    {
        return Service.InitLoginPwdAsync(req);
    }

    /// <summary>
    ///     会员密码登录
    /// </summary>
    [Transaction]
    [AllowAnonymous]
    public Task<MemberLoginRsp> LoginByPwdAsync(MemberPwdLoginReq req)
    {
        return Service.LoginByPwdAsync(req);
    }

    /// <summary>
    ///     会员短信登录
    /// </summary>
    [Transaction]
    [AllowAnonymous]
    public Task<MemberLoginRsp> LoginBySmsAsync(MemberSmsLoginReq req)
    {
        return Service.LoginBySmsAsync(req);
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
    ///     查询会员（使用邀请码）
    /// </summary>
    [AllowAnonymous]
    public Task<QueryMemberByInviteCodeRsp> QueryMemberByInviteCodeAsync(QueryMemberByInviteCodeReq req)
    {
        return Service.QueryMemberByInviteCodeAsync(req);
    }

    /// <summary>
    ///     会员注册
    /// </summary>
    [Transaction]
    [AllowAnonymous]
    public Task<RegisterMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        return Service.RegisterAsync(req);
    }

    /// <summary>
    ///     设置支付宝
    /// </summary>
    [Transaction]
    public Task SetAlipayAsync(SetAlipayReq req)
    {
        return Service.SetAlipayAsync(req);
    }

    /// <summary>
    ///     设置昵称
    /// </summary>
    [Transaction]
    public Task SetNickAsync(SetNickReq req)
    {
        return Service.SetNickAsync(req);
    }

    /// <summary>
    ///     设置交易密码
    /// </summary>
    [Transaction]
    public Task SetPayPwdAsync(SetPayPwdReq req)
    {
        return Service.SetPayPwdAsync(req);
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