using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Product;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     商品服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class ProductController : ControllerBase<IProductService>, IProductModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductController" /> class.
    /// </summary>
    public ProductController(IProductService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除商品
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建商品
    /// </summary>
    [Transaction]
    public Task<QueryProductRsp> CreateAsync(CreateProductReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除商品
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     商品是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryProductReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个商品
    /// </summary>
    [NonAction]
    public Task<QueryProductRsp> GetAsync(QueryProductReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询商品
    /// </summary>
    public Task<PagedQueryRsp<QueryProductRsp>> PagedQueryAsync(PagedQueryReq<QueryProductReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询商品
    /// </summary>
    public Task<IEnumerable<QueryProductRsp>> QueryAsync(QueryReq<QueryProductReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新商品
    /// </summary>
    [Transaction]
    public Task<QueryProductRsp> UpdateAsync(UpdateProductReq req)
    {
        return Service.UpdateAsync(req);
    }
}