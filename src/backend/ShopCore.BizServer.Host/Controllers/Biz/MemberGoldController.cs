using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员金币服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberGoldController : ControllerBase<IMemberGoldService>, IMemberGoldModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberGoldController" /> class.
    /// </summary>
    public MemberGoldController(IMemberGoldService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员金币
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员金币
    /// </summary>
    [Transaction]
    public Task<QueryMemberGoldRsp> CreateAsync(CreateMemberGoldReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员金币
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员金币是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberGoldReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员金币
    /// </summary>
    [NonAction]
    public Task<QueryMemberGoldRsp> GetAsync(QueryMemberGoldReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员金币
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberGoldRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberGoldReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员金币
    /// </summary>
    public Task<IEnumerable<QueryMemberGoldRsp>> QueryAsync(QueryReq<QueryMemberGoldReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员金币
    /// </summary>
    [Transaction]
    public Task<QueryMemberGoldRsp> UpdateAsync(UpdateMemberGoldReq req)
    {
        return Service.UpdateAsync(req);
    }
}