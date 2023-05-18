using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：设置支付宝
/// </summary>
public record SetAlipayReq : DataAbstraction
{
    /// <summary>
    ///     支付宝帐号
    /// </summary>
    [Alipay]
    [Required]
    public string AlipayAccount { get; init; }

    /// <summary>
    ///     支付宝姓名
    /// </summary>
    [Required]
    [ChineseName]
    public string AlipayName { get; init; }
}