using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Tpl.Example;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;
using ShopCore.SysComponent.Application.Modules.Tpl;
using ShopCore.SysComponent.Application.Services.Tpl.Dependency;

namespace ShopCore.SysComponent.Host.Controllers.Tpl;

/// <summary>
///     示例服务
/// </summary>
[ApiDescriptionSettings(nameof(Tpl), Module = nameof(Tpl))]
public sealed class ExampleController : ControllerBase<IExampleService>, IExampleModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ExampleController" /> class.
    /// </summary>
    public ExampleController(IExampleService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除示例
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建示例
    /// </summary>
    [Transaction]
    public Task<QueryExampleRsp> CreateAsync(CreateExampleReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除示例
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     示例是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryExampleReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个示例
    /// </summary>
    [NonAction]
    public Task<QueryExampleRsp> GetAsync(QueryExampleReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询示例
    /// </summary>
    public Task<PagedQueryRsp<QueryExampleRsp>> PagedQueryAsync(PagedQueryReq<QueryExampleReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询示例
    /// </summary>
    public Task<IEnumerable<QueryExampleRsp>> QueryAsync(QueryReq<QueryExampleReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新示例
    /// </summary>
    [Transaction]
    public Task<QueryExampleRsp> UpdateAsync(UpdateExampleReq req)
    {
        return Service.UpdateAsync(req);
    }
}