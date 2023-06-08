using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Product;
using ShopCore.Domain.Dto.Biz.ShoppingCart;
using ShopCore.Domain.Dto.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IShoppingCartService" />
public sealed class ShoppingCartService : RepositoryService<Biz_ShoppingCart, IShoppingCartService>
                                        , IShoppingCartService
{
    private readonly ContextMemberInfo _memberInfo;
    private readonly IProductService   _productService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ShoppingCartService" /> class.
    /// </summary>
    public ShoppingCartService(Repository<Biz_ShoppingCart> rpo, IProductService productService
                             , ContextMemberInfo            memberInfo) //
        : base(rpo)
    {
        _productService = productService;
        _memberInfo     = memberInfo;
    }

    /// <summary>
    ///     批量删除购物车
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
    ///     创建购物车
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">商品不存在</exception>
    public async Task<QueryShoppingCartRsp> CreateAsync(CreateShoppingCartReq req)
    {
        await CheckProductAsync(req);

        var shoppingCart
            = await GetAsync(new QueryShoppingCartReq { MemberId = _memberInfo.Id, ProductId = req.ProductId });
        Biz_ShoppingCart ret;
        if (shoppingCart is null) {
            ret = await Rpo.InsertAsync(req with { MemberId = _memberInfo.Id });
        }
        else {
            shoppingCart.Quantity += req.Quantity;
            ret                   =  await UpdateAsync(shoppingCart.Adapt<UpdateShoppingCartReq>());
        }

        return ret.Adapt<QueryShoppingCartRsp>();
    }

    /// <summary>
    ///     删除购物车
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断购物车是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryShoppingCartReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个购物车
    /// </summary>
    public async Task<QueryShoppingCartRsp> GetAsync(QueryShoppingCartReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryShoppingCartReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryShoppingCartRsp>();
    }

    /// <summary>
    ///     分页查询购物车
    /// </summary>
    public async Task<PagedQueryRsp<QueryShoppingCartRsp>> PagedQueryAsync(PagedQueryReq<QueryShoppingCartReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryShoppingCartRsp>(req.Page, req.PageSize, total
                                                     , list.Adapt<IEnumerable<QueryShoppingCartRsp>>());
    }

    /// <summary>
    ///     查询购物车
    /// </summary>
    public async Task<IEnumerable<QueryShoppingCartRsp>> QueryAsync(QueryReq<QueryShoppingCartReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryShoppingCartRsp>>();
    }

    /// <summary>
    ///     更新购物车
    /// </summary>
    public async Task<QueryShoppingCartRsp> UpdateAsync(UpdateShoppingCartReq req)
    {
        await CheckProductAsync(req);
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req)
                           .IgnoreColumns(a => new { a.MemberId, a.OwnerId, a.OwnerDeptId })
                           .ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryShoppingCartRsp>();
    }

    private async Task CheckProductAsync(Biz_ShoppingCart req)
    {
        if (!await _productService.ExistAsync(
                new QueryReq<QueryProductReq> { Filter = new QueryProductReq { Id = req.ProductId } })) {
            throw new ShopCoreInvalidOperationException(Ln.商品不存在);
        }
    }

    private ISelect<Biz_ShoppingCart> QueryInternal(QueryReq<QueryShoppingCartReq> req)
    {
        return Rpo.Select.Include(a => a.Product)
                  .WhereDynamicFilter(req.DynamicFilter)
                  .WhereIf(req.Filter?.Id is not (null or 0),        a => a.Id        == req.Filter.Id)
                  .WhereIf(req.Filter?.ProductId is not (null or 0), a => a.ProductId == req.Filter.ProductId)
                  .WhereIf(req.Filter?.MemberId is not (null or 0),  a => a.MemberId  == req.Filter.MemberId)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryShoppingCartRsp> UpdateForSqliteAsync(Biz_ShoppingCart req)
    {
        if (await Rpo.UpdateDiy.SetSource(req)
                     .IgnoreColumns(a => new { a.MemberId, a.OwnerId, a.OwnerDeptId })
                     .ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await Rpo.Select.Where(a => a.Id == req.Id).ToOneAsync();
        return ret.Adapt<QueryShoppingCartRsp>();
    }
}