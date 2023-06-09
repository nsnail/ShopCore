using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     购物车表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_ShoppingCart))]
[Index($"idx_{{tablename}}_{nameof(MemberId)}_{nameof(ProductId)}", $"{nameof(MemberId)},{nameof(ProductId)}", true)]
public record Biz_ShoppingCart : VersionEntity, IFieldOwner
{
    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long MemberId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerDeptId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public long? OwnerDeptId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public long? OwnerId { get; init; }

    /// <summary>
    ///     商品信息
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(ProductId))]
    public virtual Biz_Product Product { get; init; }

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
    public virtual int Quantity { get; set; }
}