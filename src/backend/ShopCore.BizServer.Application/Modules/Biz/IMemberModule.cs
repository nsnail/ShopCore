using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员模块
/// </summary>
public interface IMemberModule : ICrudModule<CreateMemberReq, QueryMemberRsp, QueryMemberReq, QueryMemberRsp, UpdateMemberReq, QueryMemberRsp, DelReq>
{
    /// <summary>
    ///     检查手机号是否可用
    /// </summary>
    Task<bool> CheckMobileAvailableAsync(CheckMobileAvailableReq req);

    /// <summary>
    ///     初始化登录密码
    /// </summary>
    Task InitLoginPwdAsync(InitLoginPwdReq req);

    /// <summary>
    ///     会员密码登录
    /// </summary>
    Task<MemberLoginRsp> LoginByPwdAsync(MemberPwdLoginReq req);

    /// <summary>
    ///     会员短信登录
    /// </summary>
    Task<MemberLoginRsp> LoginBySmsAsync(MemberSmsLoginReq req);

    /// <summary>
    ///     查询会员（使用邀请码）
    /// </summary>
    Task<QueryMemberByInviteCodeRsp> QueryMemberByInviteCodeAsync(QueryMemberByInviteCodeReq req);

    /// <summary>
    ///     会员注册
    /// </summary>
    Task<RegisterMemberRsp> RegisterAsync(RegisterMemberReq req);

    /// <summary>
    ///     设置支付宝
    /// </summary>
    Task SetAlipayAsync(SetAlipayReq req);

    /// <summary>
    ///     设置用户名
    /// </summary>
    Task SetNickAsync(SetNickReq req);

    /// <summary>
    ///     设置交易密码
    /// </summary>
    Task SetPayPwdAsync(SetPayPwdReq req);
}