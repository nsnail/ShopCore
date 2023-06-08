using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Biz.Product;

namespace ShopCore.Domain.Dto.Biz.ShoppingCart;

/// <summary>
///     响应：查询购物车
/// </summary>
public sealed record QueryShoppingCartRsp : Biz_ShoppingCart
{
    /// <inheritdoc cref="IFieldCreatedTime.CreatedTime" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override DateTime CreatedTime { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_ShoppingCart.Product" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public new QueryProductRsp Product { get; init; }

    /// <inheritdoc cref="Biz_ShoppingCart.Quantity" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int Quantity { get; set; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}