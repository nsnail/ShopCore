namespace ShopCore.Infrastructure.Enums;

/// <summary>
///     订单状态
/// </summary>
[Export]
public enum OrderStatues
{
    /// <summary>
    ///     未付款
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.未付款))]
    未付款 = 1

   ,

    /// <summary>
    ///     已付款
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已付款))]
    已付款 = 2

   ,

    /// <summary>
    ///     已发货
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已发货))]
    已发货 = 3

   ,

    /// <summary>
    ///     已收货
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已收货))]
    已收货 = 4

   ,

    /// <summary>
    ///     退款中
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.退款中))]
    退款中 = 5

   ,

    /// <summary>
    ///     已退款
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已退款))]
    已退款 = 6

   ,

    /// <summary>
    ///     已完成
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已完成))]
    已完成 = 7
}