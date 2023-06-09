using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.OrderItem;
using ShopCore.Domain.Dto.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IOrderItemService" />
public sealed class OrderItemService : RepositoryService<Biz_OrderItem, IOrderItemService>, IOrderItemService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderItemService" /> class.
    /// </summary>
    public OrderItemService(Repository<Biz_OrderItem> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除订单项
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
    ///     创建订单项
    /// </summary>
    public async Task<QueryOrderItemRsp> CreateAsync(CreateOrderItemReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryOrderItemRsp>();
    }

    /// <summary>
    ///     删除订单项
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断订单项是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryOrderItemReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个订单项
    /// </summary>
    public async Task<QueryOrderItemRsp> GetAsync(QueryOrderItemReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryOrderItemReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryOrderItemRsp>();
    }

    /// <summary>
    ///     分页查询订单项
    /// </summary>
    public async Task<PagedQueryRsp<QueryOrderItemRsp>> PagedQueryAsync(PagedQueryReq<QueryOrderItemReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryOrderItemRsp>(req.Page, req.PageSize, total
                                                  , list.Adapt<IEnumerable<QueryOrderItemRsp>>());
    }

    /// <summary>
    ///     查询订单项
    /// </summary>
    public async Task<IEnumerable<QueryOrderItemRsp>> QueryAsync(QueryReq<QueryOrderItemReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryOrderItemRsp>>();
    }

    /// <summary>
    ///     更新订单项
    /// </summary>
    public async Task<QueryOrderItemRsp> UpdateAsync(UpdateOrderItemReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryOrderItemRsp>();
    }

    private ISelect<Biz_OrderItem> QueryInternal(QueryReq<QueryOrderItemReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryOrderItemRsp> UpdateForSqliteAsync(Biz_OrderItem req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await Rpo.Select.Where(a => a.Id == req.Id).ToOneAsync();
        return ret.Adapt<QueryOrderItemRsp>();
    }
}