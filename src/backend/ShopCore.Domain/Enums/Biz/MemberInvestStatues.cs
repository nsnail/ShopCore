namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     会员投资状态
/// </summary>
[Export]
public enum MemberInvestStatues
{
    /// <summary>
    ///     进行中
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.进行中))]
    Running = 1

   ,

    /// <summary>
    ///     已完成
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.已完成))]
    Finished = 2
}