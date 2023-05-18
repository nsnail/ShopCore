using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Investment;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     投资服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class InvestmentController : ControllerBase<IInvestmentService>, IInvestmentModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="InvestmentController" /> class.
    /// </summary>
    public InvestmentController(IInvestmentService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除投资
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建投资
    /// </summary>
    [Transaction]
    public Task<QueryInvestmentRsp> CreateAsync(CreateInvestmentReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除投资
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     投资是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryInvestmentReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个投资
    /// </summary>
    [NonAction]
    public Task<QueryInvestmentRsp> GetAsync(QueryInvestmentReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询投资
    /// </summary>
    public Task<PagedQueryRsp<QueryInvestmentRsp>> PagedQueryAsync(PagedQueryReq<QueryInvestmentReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询投资
    /// </summary>
    public Task<IEnumerable<QueryInvestmentRsp>> QueryAsync(QueryReq<QueryInvestmentReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新投资
    /// </summary>
    [Transaction]
    public Task<QueryInvestmentRsp> UpdateAsync(UpdateInvestmentReq req)
    {
        return Service.UpdateAsync(req);
    }
}