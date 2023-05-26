using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.ProductCategory;

/// <summary>
///     请求：创建商品分类
/// </summary>
public record CreateProductCategoryReq : Biz_ProductCategory
{
    /// <inheritdoc cref="Biz_ProductCategory.CategoryName" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.分类名称))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string CategoryName { get; init; }

    /// <inheritdoc cref="Biz_ProductCategory.ParentId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long ParentId { get; init; }

    /// <inheritdoc cref="Biz_ProductCategory.Sort" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Sort { get; init; } = Numbers.DEF_SORT_VAL;
}