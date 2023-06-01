using ShopCore.Domain.Dto.Sys.Sms;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：短信登录
/// </summary>
public record LoginBySmsReq : VerifySmsCodeReq;