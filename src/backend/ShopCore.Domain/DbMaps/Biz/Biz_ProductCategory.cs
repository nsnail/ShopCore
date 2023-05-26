using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     商品分类表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_ProductCategory))]
public record Biz_ProductCategory : VersionEntity, IFieldSort
{
    /// <summary>
    ///     分类名称
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    public virtual string CategoryName { get; init; }

    /// <summary>
    ///     子节点
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(ParentId))]
    public virtual IEnumerable<Biz_ProductCategory> Children { get; init; }

    /// <summary>
    ///     父编号
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual long ParentId { get; init; }

    /// <summary>
    ///     排序值，越大越前
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual long Sort { get; init; }
}