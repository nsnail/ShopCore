using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberFixed;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员固化信息服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberFixedController : ControllerBase<IMemberFixedService>, IMemberFixedModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberFixedController" /> class.
    /// </summary>
    public MemberFixedController(IMemberFixedService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员固化信息
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员固化信息
    /// </summary>
    [Transaction]
    public Task<QueryMemberFixedRsp> CreateAsync(CreateMemberFixedReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员固化信息
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员固化信息是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberFixedReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员固化信息
    /// </summary>
    [NonAction]
    public Task<QueryMemberFixedRsp> GetAsync(QueryMemberFixedReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员固化信息
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberFixedRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberFixedReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员固化信息
    /// </summary>
    public Task<IEnumerable<QueryMemberFixedRsp>> QueryAsync(QueryReq<QueryMemberFixedReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员固化信息
    /// </summary>
    [Transaction]
    public Task<QueryMemberFixedRsp> UpdateAsync(UpdateMemberFixedReq req)
    {
        return Service.UpdateAsync(req);
    }
}