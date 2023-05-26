using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     商品表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Product))]
public record Biz_Product : VersionEntity
{
    /// <summary>
    ///     所属商品分类
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(CategoryId))]
    public virtual Biz_ProductCategory Category { get; init; }

    /// <summary>
    ///     所属商品分类编号
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual long CategoryId { get; init; }

    /// <summary>
    ///     商品描述
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    public virtual string Description { get; init; }

    /// <summary>
    ///     商品图片链接
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    public virtual string ImageUrl { get; init; }

    /// <summary>
    ///     商品名称
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    public virtual string Name { get; init; }

    /// <summary>
    ///     商品价格
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual int Price { get; init; }

    /// <summary>
    ///     商品库存
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual int Stock { get; init; }
}