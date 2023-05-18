using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：会员注册
/// </summary>
public sealed record RegisterMemberReq : RegisterReq
{
    /// <summary>
    ///     邀请者码
    /// </summary>
    [Required]
    [InviteCode]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int InviterCode { get; init; }

    /// <summary>
    ///     密码
    /// </summary>
    [JsonIgnore]
    public override string PasswordText { get; init; } = Chars.FLG_RANDOM_UNAME_PWD;

    /// <summary>
    ///     用户名
    /// </summary>
    [JsonIgnore]
    public override string UserName { get; init; } = Chars.FLG_RANDOM_UNAME_PWD;

    /// <summary>
    ///     微信OpenId
    /// </summary>
    public string WechatId { get; init; }
}