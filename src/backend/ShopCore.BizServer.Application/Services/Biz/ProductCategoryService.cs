using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.ProductCategory;
using ShopCore.Domain.Dto.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IProductCategoryService" />
public sealed class ProductCategoryService : RepositoryService<Biz_ProductCategory, IProductCategoryService>, IProductCategoryService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductCategoryService" /> class.
    /// </summary>
    public ProductCategoryService(Repository<Biz_ProductCategory> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除商品分类
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
    ///     创建商品分类
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">父节点不存在</exception>
    public async Task<QueryProductCategoryRsp> CreateAsync(CreateProductCategoryReq req)
    {
        if (req.ParentId != 0 && !await Rpo.Select.AnyAsync(a => a.Id == req.ParentId)) {
            throw new ShopCoreInvalidOperationException(Ln.父节点不存在);
        }

        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryProductCategoryRsp>();
    }

    /// <summary>
    ///     删除商品分类
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断商品分类是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryProductCategoryReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个商品分类
    /// </summary>
    public async Task<QueryProductCategoryRsp> GetAsync(QueryProductCategoryReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryProductCategoryReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryProductCategoryRsp>();
    }

    /// <summary>
    ///     分页查询商品分类
    /// </summary>
    public async Task<PagedQueryRsp<QueryProductCategoryRsp>> PagedQueryAsync(PagedQueryReq<QueryProductCategoryReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryProductCategoryRsp>(req.Page, req.PageSize, total, list.Adapt<IEnumerable<QueryProductCategoryRsp>>());
    }

    /// <summary>
    ///     查询商品分类
    /// </summary>
    public async Task<IEnumerable<QueryProductCategoryRsp>> QueryAsync(QueryReq<QueryProductCategoryReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryProductCategoryRsp>>();
    }

    /// <summary>
    ///     更新商品分类
    /// </summary>
    public async Task<QueryProductCategoryRsp> UpdateAsync(UpdateProductCategoryReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryProductCategoryRsp>();
    }

    private ISelect<Biz_ProductCategory> QueryInternal(QueryReq<QueryProductCategoryReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryProductCategoryRsp> UpdateForSqliteAsync(Biz_ProductCategory req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await Rpo.Select.Where(a => a.Id == req.Id).ToOneAsync();
        return ret.Adapt<QueryProductCategoryRsp>();
    }
}