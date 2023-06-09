using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.OrderItem;

namespace ShopCore.Domain.Dto.Biz.Order;

/// <summary>
///     请求：创建订单
/// </summary>
public record CreateOrderReq : Biz_Order, IValidatableObject
{
    /// <summary>
    ///     收货地址编号
    /// </summary>
    [CultureRange(1, long.MaxValue, ErrorMessageResourceName = nameof(Ln.地址编号), ErrorMessageResourceType = typeof(Ln))]
    public long AddressId { get; init; }

    /// <inheritdoc cref="Biz_Order.Items" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.订单项))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public new ICollection<CreateOrderItemReq> Items { get; set; }

    /// <inheritdoc cref="Biz_Order.MemberId" />
    [JsonIgnore]
    public override long MemberId { get; init; } = App.GetService<ContextMemberInfo>().Id;

    /// <inheritdoc cref="Biz_Order.Summary" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Summary { get; init; }

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Items.Select(x => x.ProductId).Distinct().Count() != Items.Count) {
            yield return new ValidationResult(Ln.订单项重复, new[] { nameof(Items) });
        }
    }
}