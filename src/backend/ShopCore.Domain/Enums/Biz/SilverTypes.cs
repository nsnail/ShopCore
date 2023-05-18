namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     银币类型
/// </summary>
[Export]
public enum SilverTypes
{
    /// <summary>
    ///     签到
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.签到))]
    Sign = 1

   ,

    /// <summary>
    ///     兑换金币
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.银币兑金币))]
    Silver2Gold = 2

   ,

    /// <summary>
    ///     管理员赠送
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.管理员赠送))]
    AdminGift = 3

   ,

    /// <summary>
    ///     浏览商品奖励
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.浏览商品奖励))]
    ViewGoodsReward = 4
}