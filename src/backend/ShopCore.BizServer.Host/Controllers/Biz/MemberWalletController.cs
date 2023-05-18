using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberWallet;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员钱包服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberWalletController : ControllerBase<IMemberWalletService>, IMemberWalletModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberWalletController" /> class.
    /// </summary>
    public MemberWalletController(IMemberWalletService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员钱包
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员钱包
    /// </summary>
    [Transaction]
    public Task<QueryMemberWalletRsp> CreateAsync(CreateMemberWalletReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员钱包
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员钱包是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberWalletReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员钱包
    /// </summary>
    [NonAction]
    public Task<QueryMemberWalletRsp> GetAsync(QueryMemberWalletReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员钱包
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberWalletRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberWalletReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员钱包
    /// </summary>
    public Task<IEnumerable<QueryMemberWalletRsp>> QueryAsync(QueryReq<QueryMemberWalletReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员钱包
    /// </summary>
    [Transaction]
    public Task<QueryMemberWalletRsp> UpdateAsync(UpdateMemberWalletReq req)
    {
        return Service.UpdateAsync(req);
    }
}