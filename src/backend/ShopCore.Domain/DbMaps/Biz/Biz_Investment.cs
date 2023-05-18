using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     投资表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Investment))]
public record Biz_Investment : VersionEntity
{
    /// <summary>
    ///     计息天数
    /// </summary>
    [Column]
    [JsonIgnore]
    public int Days { get; set; }

    /// <summary>
    ///     投资金币数下限
    /// </summary>
    [Column]
    [JsonIgnore]
    public int GoldLower { get; set; }

    /// <summary>
    ///     年化利率
    /// </summary>
    [Column]
    [JsonIgnore]
    public decimal Rate { get; set; }

    /// <summary>
    ///     状态
    /// </summary>
    [Column]
    [JsonIgnore]
    public InvestStatues Status { get; set; }

    /// <summary>
    ///     记录更新时间
    /// </summary>
    [Column]
    [JsonIgnore]
    public DateTime UpdateTime { get; set; }
}