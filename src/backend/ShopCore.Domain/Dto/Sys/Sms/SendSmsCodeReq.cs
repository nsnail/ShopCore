using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Sys.Captcha;
using ShopCore.Domain.Enums.Sys;

namespace ShopCore.Domain.Dto.Sys.Sms;

/// <summary>
///     请求：发送短信验证码
/// </summary>
public sealed record SendSmsCodeReq : Sys_Sms
{
    /// <inheritdoc cref="Sys_Sms.DestMobile" />
    [NotEmpty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string DestMobile { get; init; }

    /// <inheritdoc cref="Sys_Sms.Status" />
    public override SmsStatues Status => SmsStatues.Waiting;

    /// <inheritdoc cref="Sys_Sms.Type" />
    [NotEmpty]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override SmsTypes Type { get; init; }

    /// <summary>
    ///     人机校验请求
    /// </summary>
    [NotEmpty]
    public VerifyCaptchaReq VerifyCaptchaReq { get; init; }
}