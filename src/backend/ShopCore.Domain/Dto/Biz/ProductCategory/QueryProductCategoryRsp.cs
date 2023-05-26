using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.ProductCategory;

/// <summary>
///     响应：查询商品分类
/// </summary>
public sealed record QueryProductCategoryRsp : Biz_ProductCategory
{
    /// <inheritdoc cref="Biz_ProductCategory.CategoryName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string CategoryName { get; init; }

    /// <summary>
    ///     子节点
    /// </summary>
    public new IEnumerable<QueryProductCategoryRsp> Children { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_ProductCategory.ParentId" />
    public override long ParentId { get; init; }

    /// <inheritdoc cref="Biz_ProductCategory.Sort" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Sort { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}