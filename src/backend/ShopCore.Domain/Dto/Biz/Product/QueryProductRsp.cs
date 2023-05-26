using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Biz.ProductCategory;

namespace ShopCore.Domain.Dto.Biz.Product;

/// <summary>
///     响应：查询商品
/// </summary>
public sealed record QueryProductRsp : Biz_Product
{
    /// <inheritdoc cref="Biz_Product.Category" />
    public new QueryProductCategoryRsp Category { get; init; }

    /// <inheritdoc cref="Biz_Product.CategoryId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long CategoryId { get; init; }

    /// <inheritdoc cref="IFieldCreatedTime.CreatedTime" />
    public override DateTime CreatedTime { get; init; }

    /// <inheritdoc cref="Biz_Product.Description" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Description { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_Product.ImageUrl" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string ImageUrl { get; init; }

    /// <inheritdoc cref="IFieldModifiedTime.ModifiedTime" />
    public override DateTime? ModifiedTime { get; init; }

    /// <inheritdoc cref="Biz_Product.Name" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Name { get; init; }

    /// <inheritdoc cref="Biz_Product.Price" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int Price { get; init; }

    /// <inheritdoc cref="Biz_Product.Stock" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int Stock { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}