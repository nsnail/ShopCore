using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     订单项表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_OrderItem))]
public record Biz_OrderItem : VersionEntity, IFieldOwner
{
    /// <summary>
    ///     商品图片链接
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    [JsonIgnore]
    public virtual string ImageUrl { get; init; }

    /// <summary>
    ///     商品名称
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string Name { get; init; }

    /// <summary>
    ///     订单编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long OrderId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerDeptId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public virtual long? OwnerDeptId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public virtual long? OwnerId { get; init; }

    /// <summary>
    ///     商品价格
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int Price { get; init; }

    /// <summary>
    ///     商品编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long ProductId { get; init; }

    /// <summary>
    ///     商品数量
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int Quantity { get; init; }
}