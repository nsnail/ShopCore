using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Address;
using ShopCore.Domain.Dto.Biz.Order;
using ShopCore.Domain.Dto.Biz.OrderItem;
using ShopCore.Domain.Dto.Biz.Product;
using ShopCore.Domain.Dto.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IOrderService" />
public sealed class OrderService : RepositoryService<Biz_Order, IOrderService>, IOrderService
{
    private readonly IAddressService _addressService;
    private readonly IProductService _productService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderService" /> class.
    /// </summary>
    public OrderService(Repository<Biz_Order> rpo, IProductService productService, IAddressService addressService) //
        : base(rpo)
    {
        _productService = productService;
        _addressService = addressService;
    }

    /// <summary>
    ///     批量删除订单
    /// </summary>
    public async Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        var sum = 0;
        foreach (var item in req.Items) {
            sum += await DeleteAsync(item);
        }

        return sum;
    }

    /// <summary>
    ///     创建订单
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">商品不存在</exception>
    public async Task<QueryOrderRsp> CreateAsync(CreateOrderReq req)
    {
        EnableCascadeSave = true;

        // 读取地址信息
        var address = await _addressService.GetAsync(new QueryAddressReq { Id = req.AddressId });
        if (address == null) {
            throw new ShopCoreInvalidOperationException(Ln.地址编号不存在);
        }

        // 读取商品信息
        var productIds = req.Items.Select(x => x.ProductId);
        var products = (await _productService.QueryAsync(new QueryReq<QueryProductReq> {
                                                             DynamicFilter
                                                                 = new DynamicFilterInfo {
                                                                       Field    = nameof(QueryProductReq.Id)
                                                                     , Operator = DynamicFilterOperator.Any
                                                                     , Value    = productIds
                                                                   }
                                                         })).ToList();

        if (products.Count != req.Items.Count) {
            throw new ShopCoreInvalidOperationException(Ln.商品不存在);
        }

        req.AreaId         = address.AreaId;
        req.StreetAddress  = address.StreetAddress;
        req.RecipientPhone = address.RecipientPhone;
        req.RecipientName  = address.RecipientName;
        req.Items = products.ConvertAll(x => x.Adapt<CreateOrderItemReq>() with {
                                                 Quantity = req.Items.Single(y => y.ProductId == x.Id).Quantity
                                             });
        req.TotalAmount = req.Items.Sum(x => x.Price * x.Quantity);
        req.Status      = OrderStatues.未付款;

        var ret = await Rpo.InsertAsync(req.Adapt<Biz_Order>());
        return ret.Adapt<QueryOrderRsp>();
    }

    /// <summary>
    ///     删除订单
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断订单是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryOrderReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个订单
    /// </summary>
    public async Task<QueryOrderRsp> GetAsync(QueryOrderReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryOrderReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryOrderRsp>();
    }

    /// <summary>
    ///     分页查询订单
    /// </summary>
    public async Task<PagedQueryRsp<QueryOrderRsp>> PagedQueryAsync(PagedQueryReq<QueryOrderReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryOrderRsp>(req.Page, req.PageSize, total
                                              , list.Adapt<IEnumerable<QueryOrderRsp>>());
    }

    /// <summary>
    ///     查询订单
    /// </summary>
    public async Task<IEnumerable<QueryOrderRsp>> QueryAsync(QueryReq<QueryOrderReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryOrderRsp>>();
    }

    /// <summary>
    ///     更新订单
    /// </summary>
    public async Task<QueryOrderRsp> UpdateAsync(UpdateOrderReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryOrderRsp>();
    }

    private ISelect<Biz_Order> QueryInternal(QueryReq<QueryOrderReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryOrderRsp> UpdateForSqliteAsync(Biz_Order req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await Rpo.Select.Where(a => a.Id == req.Id).ToOneAsync();
        return ret.Adapt<QueryOrderRsp>();
    }
}