using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.ShoppingCart;

/// <summary>
///     请求：创建购物车
/// </summary>
public record CreateShoppingCartReq : Biz_ShoppingCart
{
    /// <inheritdoc cref="Biz_Address.MemberId" />
    [JsonIgnore]
    public override long MemberId { get; init; } = App.GetService<ContextMemberInfo>().Id;

    /// <inheritdoc cref="Biz_ShoppingCart.ProductId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(1, long.MaxValue, ErrorMessageResourceName = nameof(Ln.商品编号), ErrorMessageResourceType = typeof(Ln))]
    public override long ProductId { get; init; }

    /// <inheritdoc cref="Biz_ShoppingCart.Quantity" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRange(1, 1000, ErrorMessageResourceName = nameof(Ln.商品数量), ErrorMessageResourceType = typeof(Ln))]
    public override int Quantity { get; set; }
}