using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.Product;

/// <summary>
///     请求：更新商品
/// </summary>
public sealed record UpdateProductReq : CreateProductReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}