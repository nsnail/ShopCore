using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员银币表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberSilver))]
public record Biz_MemberSilver : LiteImmutableEntity
{
    /// <summary>
    ///     交易数量
    /// </summary>
    [Column]
    public long Amount { get; set; }

    /// <summary>
    ///     交易后余额
    /// </summary>
    [Column]
    public long BalanceAfter { get; set; }

    /// <summary>
    ///     交易前余额
    /// </summary>
    [Column]
    public long BalanceBefore { get; set; }

    /// <summary>
    ///     附加数据
    /// </summary>
    [Column]
    public string Data { get; set; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    public long MemberId { get; set; }

    /// <summary>
    ///     交易类型
    /// </summary>
    [Column]
    public SilverTypes Type { get; set; }
}