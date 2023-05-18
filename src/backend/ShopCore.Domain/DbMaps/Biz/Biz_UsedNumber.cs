using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     取号表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_UsedNumber))]
[Index($"idx_{{tablename}}_{nameof(Number)}", nameof(Number), true)]
public record Biz_UsedNumber : LiteImmutableEntity
{
    /// <summary>
    ///     数字
    /// </summary>
    [JsonIgnore]
    public long Number { get; init; }
}