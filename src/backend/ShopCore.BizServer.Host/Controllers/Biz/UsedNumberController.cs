using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.UsedNumber;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     取号服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class UsedNumberController : ControllerBase<IUsedNumberService>, IUsedNumberModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UsedNumberController" /> class.
    /// </summary>
    public UsedNumberController(IUsedNumberService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除取号
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建取号
    /// </summary>
    [Transaction]
    public Task<QueryUsedNumberRsp> CreateAsync(CreateUsedNumberReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除取号
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     取号是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryUsedNumberReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个取号
    /// </summary>
    [NonAction]
    public Task<QueryUsedNumberRsp> GetAsync(QueryUsedNumberReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询取号
    /// </summary>
    public Task<PagedQueryRsp<QueryUsedNumberRsp>> PagedQueryAsync(PagedQueryReq<QueryUsedNumberReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询取号
    /// </summary>
    public Task<IEnumerable<QueryUsedNumberRsp>> QueryAsync(QueryReq<QueryUsedNumberReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新取号
    /// </summary>
    [Transaction]
    public Task<QueryUsedNumberRsp> UpdateAsync(UpdateUsedNumberReq req)
    {
        return Service.UpdateAsync(req);
    }
}