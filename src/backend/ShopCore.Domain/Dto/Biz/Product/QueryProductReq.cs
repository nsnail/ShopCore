using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.Product;

/// <summary>
///     请求：查询商品
/// </summary>
public sealed record QueryProductReq : Biz_Product
{
    /// <inheritdoc cref="Biz_Product.CategoryId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long CategoryId { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }
}