namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     会员等级
/// </summary>
[Export]
public enum MemberLevels
{
    /// <summary>
    ///     钻石VIP
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.钻石))]
    Diamond = 0

   ,

    /// <summary>
    ///     铂金VIP
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.铂金))]
    Platinum = 1

   ,

    /// <summary>
    ///     黄金VIP
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.黄金))]
    Gold = 2

   ,

    /// <summary>
    ///     白银VIP
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.白银))]
    Silver = 3
}