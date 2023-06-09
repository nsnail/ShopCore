using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Product;

namespace ShopCore.Domain.Dto.Biz.OrderItem;

/// <summary>
///     请求：创建订单项
/// </summary>
public record CreateOrderItemReq : Biz_OrderItem, IRegister
{
    /// <inheritdoc cref="Biz_OrderItem.ProductId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(1, long.MaxValue, ErrorMessageResourceName = nameof(Ln.商品编号), ErrorMessageResourceType = typeof(Ln))]
    public override long ProductId { get; init; }

    /// <inheritdoc cref="Biz_OrderItem.Quantity" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(1, 1000, ErrorMessageResourceName = nameof(Ln.商品数量), ErrorMessageResourceType = typeof(Ln))]
    public override int Quantity { get; init; }

    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<QueryProductRsp, CreateOrderItemReq>() //
                  .Map(d => d.ProductId, s => s.Id)
                  .Map(d => d.Id,        _ => 0)

            //
            ;
    }
}