using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.ProductCategory;

/// <summary>
///     请求：更新商品分类
/// </summary>
public sealed record UpdateProductCategoryReq : CreateProductCategoryReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}