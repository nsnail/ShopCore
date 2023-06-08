using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.ShoppingCart;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     购物车服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class ShoppingCartController : ControllerBase<IShoppingCartService>, IShoppingCartModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShoppingCartController" /> class.
    /// </summary>
    public ShoppingCartController(IShoppingCartService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除购物车
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建购物车
    /// </summary>
    [Transaction]
    public Task<QueryShoppingCartRsp> CreateAsync(CreateShoppingCartReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除购物车
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     购物车是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryShoppingCartReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个购物车
    /// </summary>
    [NonAction]
    public Task<QueryShoppingCartRsp> GetAsync(QueryShoppingCartReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询购物车
    /// </summary>
    public Task<PagedQueryRsp<QueryShoppingCartRsp>> PagedQueryAsync(PagedQueryReq<QueryShoppingCartReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询购物车
    /// </summary>
    public Task<IEnumerable<QueryShoppingCartRsp>> QueryAsync(QueryReq<QueryShoppingCartReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新购物车
    /// </summary>
    [Transaction]
    public Task<QueryShoppingCartRsp> UpdateAsync(UpdateShoppingCartReq req)
    {
        return Service.UpdateAsync(req);
    }
}