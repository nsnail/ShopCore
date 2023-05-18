using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员金币表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberGold))]
public record Biz_MemberGold : LiteImmutableEntity
{
    /// <summary>
    ///     交易数量
    /// </summary>
    [Column]
    [JsonIgnore]
    public long Amount { get; set; }

    /// <summary>
    ///     交易后余额
    /// </summary>
    [Column]
    [JsonIgnore]
    public long BalanceAfter { get; set; }

    /// <summary>
    ///     交易前余额
    /// </summary>
    [Column]
    [JsonIgnore]
    public long BalanceBefore { get; set; }

    /// <summary>
    ///     附加数据
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR1022)]
    [JsonIgnore]
    public string Data { get; set; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long MemberId { get; set; }

    /// <summary>
    ///     交易类型
    /// </summary>
    [Column]
    [JsonIgnore]
    public GoldTypes Type { get; set; }
}