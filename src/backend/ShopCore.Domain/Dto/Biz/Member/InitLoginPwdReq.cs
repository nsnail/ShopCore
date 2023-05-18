using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：初始化登录密码
/// </summary>
public sealed record InitLoginPwdReq : DataAbstraction
{
    /// <summary>
    ///     密码
    /// </summary>
    [Required]
    [Password]
    public string Password { get; init; }
}