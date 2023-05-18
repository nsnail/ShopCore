using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员投资表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberInvestment))]
public record Biz_MemberInvestment : VersionEntity
{
    /// <summary>
    ///     本金
    /// </summary>
    [Column]
    [JsonIgnore]
    public long GoldCapital { get; set; }

    /// <summary>
    ///     总利息
    /// </summary>
    [Column]
    [JsonIgnore]
    public long GoldInterest { get; set; }

    /// <summary>
    ///     投资编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long InvestId { get; set; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long MemberId { get; set; }

    /// <summary>
    ///     状态
    /// </summary>
    [Column]
    [JsonIgnore]
    public MemberInvestStatues Status { get; set; }
}