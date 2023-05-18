namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     投资状态
/// </summary>
[Export]
public enum InvestStatues
{
    /// <summary>
    ///     在线
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.在线))]
    Online = 1

   ,

    /// <summary>
    ///     离线
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.离线))]
    Offline = 2
}