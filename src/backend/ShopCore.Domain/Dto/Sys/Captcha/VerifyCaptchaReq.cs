using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Sys.Captcha;

/// <summary>
///     请求：完成人机验证
/// </summary>
public sealed record VerifyCaptchaReq : DataAbstraction
{
    /// <summary>
    ///     唯一编码
    /// </summary>
    [NotEmpty]
    public string Id { get; init; }

    /// <summary>
    ///     缺口x坐标
    /// </summary>
    [JsonIgnore]
    public int? SawOffsetX { get; init; }

    /// <summary>
    ///     验证数据
    /// </summary>
    [NotEmpty]
    public string VerifyData { get; init; }
}