using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Address;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     地址服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class AddressController : ControllerBase<IAddressService>, IAddressModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressController" /> class.
    /// </summary>
    public AddressController(IAddressService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除地址
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建地址
    /// </summary>
    [Transaction]
    public Task<QueryAddressRsp> CreateAsync(CreateAddressReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除地址
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     地址是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryAddressReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个地址
    /// </summary>
    [NonAction]
    public Task<QueryAddressRsp> GetAsync(QueryAddressReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询地址
    /// </summary>
    public Task<PagedQueryRsp<QueryAddressRsp>> PagedQueryAsync(PagedQueryReq<QueryAddressReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询地址
    /// </summary>
    public Task<IEnumerable<QueryAddressRsp>> QueryAsync(QueryReq<QueryAddressReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新地址
    /// </summary>
    [Transaction]
    public Task<QueryAddressRsp> UpdateAsync(UpdateAddressReq req)
    {
        return Service.UpdateAsync(req);
    }
}