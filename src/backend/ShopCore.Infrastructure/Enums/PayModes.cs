namespace ShopCore.Infrastructure.Enums;

/// <summary>
///     支付方式
/// </summary>
[Export]
public enum PayModes
{
    /// <summary>
    ///     支付宝
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.支付宝))]
    支付宝 = 1

   ,

    /// <summary>
    ///     微信
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.微信))]
    微信 = 2

   ,

    /// <summary>
    ///     银行卡
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.银行卡))]
    银行卡 = 3

   ,

    /// <summary>
    ///     余额
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.余额))]
    余额 = 4
}