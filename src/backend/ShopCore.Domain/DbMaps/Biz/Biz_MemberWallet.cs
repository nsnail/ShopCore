using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员钱包表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberWallet))]
public record Biz_MemberWallet : VersionEntity
{
    /// <summary>
    ///     金币余额
    /// </summary>
    [Column]
    [JsonIgnore]
    public long Gold { get; set; }

    /// <summary>
    ///     订单收入
    /// </summary>
    [Column]
    [JsonIgnore]
    public long GoldOfOrder { get; set; }

    /// <summary>
    ///     累计获得金币
    /// </summary>
    [Column]
    [JsonIgnore]
    public long GoldOfSum { get; set; }

    /// <summary>
    ///     会员
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(Id))]
    public Biz_Member Member { get; init; }

    /// <summary>
    ///     连续签到天数
    /// </summary>
    [Column]
    [JsonIgnore]
    public int SignDays { get; init; }

    /// <summary>
    ///     银币余额
    /// </summary>
    [Column]
    [JsonIgnore]
    public long Silver { get; set; }
}