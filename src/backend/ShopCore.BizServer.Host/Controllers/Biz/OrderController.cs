using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Order;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     订单服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class OrderController : ControllerBase<IOrderService>, IOrderModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderController" /> class.
    /// </summary>
    public OrderController(IOrderService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除订单
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建订单
    /// </summary>
    [Transaction]
    public Task<QueryOrderRsp> CreateAsync(CreateOrderReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除订单
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     订单是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryOrderReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个订单
    /// </summary>
    [NonAction]
    public Task<QueryOrderRsp> GetAsync(QueryOrderReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询订单
    /// </summary>
    public Task<PagedQueryRsp<QueryOrderRsp>> PagedQueryAsync(PagedQueryReq<QueryOrderReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询订单
    /// </summary>
    public Task<IEnumerable<QueryOrderRsp>> QueryAsync(QueryReq<QueryOrderReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新订单
    /// </summary>
    [Transaction]
    public Task<QueryOrderRsp> UpdateAsync(UpdateOrderReq req)
    {
        return Service.UpdateAsync(req);
    }
}