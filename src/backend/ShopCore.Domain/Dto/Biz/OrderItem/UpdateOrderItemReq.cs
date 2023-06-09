using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.OrderItem;

/// <summary>
///     请求：更新订单项
/// </summary>
public sealed record UpdateOrderItemReq : CreateOrderItemReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}