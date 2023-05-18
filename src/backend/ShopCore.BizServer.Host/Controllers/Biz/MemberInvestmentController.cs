using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.MemberInvestment;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员投资服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberInvestmentController : ControllerBase<IMemberInvestmentService>, IMemberInvestmentModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberInvestmentController" /> class.
    /// </summary>
    public MemberInvestmentController(IMemberInvestmentService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员投资
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员投资
    /// </summary>
    [Transaction]
    public Task<QueryMemberInvestmentRsp> CreateAsync(CreateMemberInvestmentReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员投资
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员投资是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberInvestmentReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员投资
    /// </summary>
    [NonAction]
    public Task<QueryMemberInvestmentRsp> GetAsync(QueryMemberInvestmentReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员投资
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberInvestmentRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberInvestmentReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员投资
    /// </summary>
    public Task<IEnumerable<QueryMemberInvestmentRsp>> QueryAsync(QueryReq<QueryMemberInvestmentReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新会员投资
    /// </summary>
    [Transaction]
    public Task<QueryMemberInvestmentRsp> UpdateAsync(UpdateMemberInvestmentReq req)
    {
        return Service.UpdateAsync(req);
    }
}