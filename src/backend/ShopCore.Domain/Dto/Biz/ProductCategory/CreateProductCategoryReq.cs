using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.ProductCategory;

/// <summary>
///     请求：创建商品分类
/// </summary>
public record CreateProductCategoryReq : Biz_ProductCategory
{
    /// <summary>
    ///     分类名称
    /// </summary>
    [NotEmpty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string CategoryName { get; init; }

    /// <summary>
    ///     父id
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long ParentId { get; init; }

    /// <summary>
    ///     排序值，越大越前
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Sort { get; init; } = Numbers.DEF_SORT_VAL;
}