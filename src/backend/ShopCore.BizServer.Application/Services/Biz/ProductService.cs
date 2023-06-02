using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Product;
using ShopCore.Domain.Dto.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IProductService" />
public sealed class ProductService : RepositoryService<Biz_Product, IProductService>, IProductService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductService" /> class.
    /// </summary>
    public ProductService(Repository<Biz_Product> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除商品
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
    ///     创建商品
    /// </summary>
    public async Task<QueryProductRsp> CreateAsync(CreateProductReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryProductRsp>();
    }

    /// <summary>
    ///     删除商品
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断商品是否存在
    /// </summary>
    public async Task<bool> ExistAsync(QueryReq<QueryProductReq> req)
    {
        return await (await QueryInternalAsync(req)).AnyAsync();
    }

    /// <summary>
    ///     获取单个商品
    /// </summary>
    public async Task<QueryProductRsp> GetAsync(QueryProductReq req)
    {
        var ret = await (await QueryInternalAsync(new QueryReq<QueryProductReq> { Filter = req })).ToOneAsync();
        return ret.Adapt<QueryProductRsp>();
    }

    /// <summary>
    ///     分页查询商品
    /// </summary>
    public async Task<PagedQueryRsp<QueryProductRsp>> PagedQueryAsync(PagedQueryReq<QueryProductReq> req)
    {
        var list = await (await QueryInternalAsync(req)).Page(req.Page, req.PageSize)
                                                        .Count(out var total)
                                                        .ToListAsync();

        return new PagedQueryRsp<QueryProductRsp>(req.Page, req.PageSize, total
                                                , list.Adapt<IEnumerable<QueryProductRsp>>());
    }

    /// <summary>
    ///     查询商品
    /// </summary>
    public async Task<IEnumerable<QueryProductRsp>> QueryAsync(QueryReq<QueryProductReq> req)
    {
        var ret = await (await QueryInternalAsync(req)).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryProductRsp>>();
    }

    /// <summary>
    ///     更新商品
    /// </summary>
    public async Task<QueryProductRsp> UpdateAsync(UpdateProductReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryProductRsp>();
    }

    private async Task<ISelect<Biz_Product>> QueryInternalAsync(QueryReq<QueryProductReq> req)
    {
        List<long> recursiveCateIds = null;
        if (req.Filter?.CategoryId > 0) {
            recursiveCateIds = await Rpo.Orm.Select<Biz_ProductCategory>()
                                        .Where(a => a.Id == req.Filter.CategoryId)
                                        .AsTreeCte()
                                        .ToListAsync(a => a.Id);
        }

        return Rpo.Select.Include(a => a.Category)
                  .WhereDynamicFilter(req.DynamicFilter)
                  .WhereIf( //
                      req.Filter?.Id > 0, a => a.Id == req.Filter.Id)
                  .WhereIf( //
                      !recursiveCateIds.NullOrEmpty(), a => recursiveCateIds.Contains(a.CategoryId))
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryProductRsp> UpdateForSqliteAsync(Biz_Product req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await (await QueryInternalAsync(
            new QueryReq<QueryProductReq> { Filter = new QueryProductReq { Id = req.Id } })).ToOneAsync();
        return ret.Adapt<QueryProductRsp>();
    }
}