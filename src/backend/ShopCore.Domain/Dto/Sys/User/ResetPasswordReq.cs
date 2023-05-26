using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Dto.Sys.Sms;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：重置密码
/// </summary>
public sealed record ResetPasswordReq : DataAbstraction
{
    /// <summary>
    ///     密码
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.密码))]
    [Password]
    public string PasswordText { get; init; }

    /// <summary>
    ///     短信验证请求
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.短信验证请求))]
    public VerifySmsCodeReq VerifySmsCodeReq { get; init; }
}