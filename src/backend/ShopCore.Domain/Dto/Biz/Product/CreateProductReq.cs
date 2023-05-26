using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Product;

/// <summary>
///     请求：创建商品
/// </summary>
public record CreateProductReq : Biz_Product
{
    /// <inheritdoc cref="Biz_Product.CategoryId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long CategoryId { get; init; }

    /// <inheritdoc cref="Biz_Product.Description" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.商品描述))]
    public override string Description { get; init; }

    /// <inheritdoc cref="Biz_Product.ImageUrl" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.商品图片))]
    [Url]
    public override string ImageUrl { get; init; }

    /// <inheritdoc cref="Biz_Product.Name" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.商品名称))]
    public override string Name { get; init; }

    /// <inheritdoc cref="Biz_Product.Price" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(1, int.MaxValue, ErrorMessageResourceName = nameof(Ln.价格), ErrorMessageResourceType = typeof(Ln))]
    public override int Price { get; init; }

    /// <inheritdoc cref="Biz_Product.Stock" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(0, int.MaxValue, ErrorMessageResourceName = nameof(Ln.库存), ErrorMessageResourceType = typeof(Ln))]
    public override int Stock { get; init; }
}