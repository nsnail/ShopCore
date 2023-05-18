using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberChange;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员变更服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberChangeController : ControllerBase<IMemberChangeService>, IMemberChangeModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberChangeController" /> class.
    /// </summary>
    public MemberChangeController(IMemberChangeService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员变更
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员变更
    /// </summary>
    [Transaction]
    public Task<QueryMemberChangeRsp> CreateAsync(CreateMemberChangeReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员变更
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员变更是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberChangeReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员变更
    /// </summary>
    [NonAction]
    public Task<QueryMemberChangeRsp> GetAsync(QueryMemberChangeReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员变更
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberChangeRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberChangeReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员变更
    /// </summary>
    public Task<IEnumerable<QueryMemberChangeRsp>> QueryAsync(QueryReq<QueryMemberChangeReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员变更
    /// </summary>
    [Transaction]
    public Task<QueryMemberChangeRsp> UpdateAsync(UpdateMemberChangeReq req)
    {
        return Service.UpdateAsync(req);
    }
}