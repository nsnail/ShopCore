using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberSilver;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员银币服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberSilverController : ControllerBase<IMemberSilverService>, IMemberSilverModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberSilverController" /> class.
    /// </summary>
    public MemberSilverController(IMemberSilverService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员银币
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员银币
    /// </summary>
    [Transaction]
    public Task<QueryMemberSilverRsp> CreateAsync(CreateMemberSilverReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员银币
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员银币是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberSilverReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员银币
    /// </summary>
    [NonAction]
    public Task<QueryMemberSilverRsp> GetAsync(QueryMemberSilverReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员银币
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberSilverRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberSilverReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员银币
    /// </summary>
    public Task<IEnumerable<QueryMemberSilverRsp>> QueryAsync(QueryReq<QueryMemberSilverReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员银币
    /// </summary>
    [Transaction]
    public Task<QueryMemberSilverRsp> UpdateAsync(UpdateMemberSilverReq req)
    {
        return Service.UpdateAsync(req);
    }
}