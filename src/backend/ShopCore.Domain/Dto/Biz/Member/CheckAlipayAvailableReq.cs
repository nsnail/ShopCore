using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：检查支付宝帐号是否可用
/// </summary>
public record CheckAlipayAvailableReq : DataAbstraction
{
    /// <summary>
    ///     支付宝帐号
    /// </summary>
    [Alipay]
    [Required]
    public string AlipayAccount { get; init; }
}