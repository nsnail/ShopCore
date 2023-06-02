using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.ProductCategory;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     商品分类服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class ProductCategoryController : ControllerBase<IProductCategoryService>, IProductCategoryModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductCategoryController" /> class.
    /// </summary>
    public ProductCategoryController(IProductCategoryService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除商品分类
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建商品分类
    /// </summary>
    [Transaction]
    public Task<QueryProductCategoryRsp> CreateAsync(CreateProductCategoryReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除商品分类
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     商品分类是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryProductCategoryReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个商品分类
    /// </summary>
    [NonAction]
    public Task<QueryProductCategoryRsp> GetAsync(QueryProductCategoryReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询商品分类
    /// </summary>
    public Task<PagedQueryRsp<QueryProductCategoryRsp>> PagedQueryAsync(PagedQueryReq<QueryProductCategoryReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询商品分类
    /// </summary>
    [AllowAnonymous]
    public Task<IEnumerable<QueryProductCategoryRsp>> QueryAsync(QueryReq<QueryProductCategoryReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新商品分类
    /// </summary>
    [Transaction]
    public Task<QueryProductCategoryRsp> UpdateAsync(UpdateProductCategoryReq req)
    {
        return Service.UpdateAsync(req);
    }
}