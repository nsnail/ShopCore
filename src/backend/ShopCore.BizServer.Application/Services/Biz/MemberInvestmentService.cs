using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.MemberInvestment;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberInvestmentService" />
public sealed class MemberInvestmentService : RepositoryService<Biz_MemberInvestment, IMemberInvestmentService>
                                            , IMemberInvestmentService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberInvestmentService" /> class.
    /// </summary>
    public MemberInvestmentService(Repository<Biz_MemberInvestment> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除会员投资
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
    ///     创建会员投资
    /// </summary>
    public async Task<QueryMemberInvestmentRsp> CreateAsync(CreateMemberInvestmentReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberInvestmentRsp>();
    }

    /// <summary>
    ///     删除会员投资
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员投资是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberInvestmentReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员投资
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberInvestmentRsp> GetAsync(QueryMemberInvestmentReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询会员投资
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberInvestmentRsp>> PagedQueryAsync(
        PagedQueryReq<QueryMemberInvestmentReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberInvestmentRsp>(req.Page, req.PageSize, total
                                                         , list.Adapt<IEnumerable<QueryMemberInvestmentRsp>>());
    }

    /// <summary>
    ///     查询会员投资
    /// </summary>
    public async Task<IEnumerable<QueryMemberInvestmentRsp>> QueryAsync(QueryReq<QueryMemberInvestmentReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberInvestmentRsp>>();
    }

    /// <summary>
    ///     更新会员投资
    /// </summary>
    public async Task<QueryMemberInvestmentRsp> UpdateAsync(UpdateMemberInvestmentReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberInvestmentRsp>();
    }

    private ISelect<Biz_MemberInvestment> QueryInternal(QueryReq<QueryMemberInvestmentReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}