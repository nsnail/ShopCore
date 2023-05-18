using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Investment;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IInvestmentService" />
public sealed class InvestmentService : RepositoryService<Biz_Investment, IInvestmentService>, IInvestmentService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="InvestmentService" /> class.
    /// </summary>
    public InvestmentService(Repository<Biz_Investment> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除投资
    /// </summary>
    public async Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        var sum = 0;
        foreach (var item in req.Items) {
            sum += await DeleteAsync(item);
        }

        return sum;
    }

    /// <summary>
    ///     创建投资
    /// </summary>
    public async Task<QueryInvestmentRsp> CreateAsync(CreateInvestmentReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryInvestmentRsp>();
    }

    /// <summary>
    ///     删除投资
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断投资是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryInvestmentReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个投资
    /// </summary>
    public async Task<QueryInvestmentRsp> GetAsync(QueryInvestmentReq req)
    {
        return (await QueryInternal(new QueryReq<QueryInvestmentReq> { Filter = req }).ToOneAsync())
            .Adapt<QueryInvestmentRsp>();
    }

    /// <summary>
    ///     分页查询投资
    /// </summary>
    public async Task<PagedQueryRsp<QueryInvestmentRsp>> PagedQueryAsync(PagedQueryReq<QueryInvestmentReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryInvestmentRsp>(req.Page, req.PageSize, total
                                                   , list.Adapt<IEnumerable<QueryInvestmentRsp>>());
    }

    /// <summary>
    ///     查询投资
    /// </summary>
    public async Task<IEnumerable<QueryInvestmentRsp>> QueryAsync(QueryReq<QueryInvestmentReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryInvestmentRsp>>();
    }

    /// <summary>
    ///     更新投资
    /// </summary>
    public async Task<QueryInvestmentRsp> UpdateAsync(UpdateInvestmentReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryInvestmentRsp>();
    }

    private ISelect<Biz_Investment> QueryInternal(QueryReq<QueryInvestmentReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}