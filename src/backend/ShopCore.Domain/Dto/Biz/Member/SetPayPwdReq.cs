using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Dto.Sys.Sms;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：设置交易密码
/// </summary>
public record SetPayPwdReq : VerifySmsCodeReq
{
    /// <summary>
    ///     交易密码
    /// </summary>
    [Required]
    [PayPassword]
    public string PayPwd { get; init; }
}