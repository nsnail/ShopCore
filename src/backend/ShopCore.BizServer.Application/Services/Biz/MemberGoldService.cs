using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberGoldService" />
public sealed class MemberGoldService : RepositoryService<Biz_MemberGold, IMemberGoldService>, IMemberGoldService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberGoldService" /> class.
    /// </summary>
    public MemberGoldService(Repository<Biz_MemberGold> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除会员金币
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
    ///     创建会员金币
    /// </summary>
    public async Task<QueryMemberGoldRsp> CreateAsync(CreateMemberGoldReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberGoldRsp>();
    }

    /// <summary>
    ///     删除会员金币
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员金币是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberGoldReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员金币
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberGoldRsp> GetAsync(QueryMemberGoldReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询会员金币
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberGoldRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberGoldReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberGoldRsp>(req.Page, req.PageSize, total
                                                   , list.Adapt<IEnumerable<QueryMemberGoldRsp>>());
    }

    /// <summary>
    ///     查询会员金币
    /// </summary>
    public async Task<IEnumerable<QueryMemberGoldRsp>> QueryAsync(QueryReq<QueryMemberGoldReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberGoldRsp>>();
    }

    /// <summary>
    ///     更新会员金币
    /// </summary>
    public async Task<QueryMemberGoldRsp> UpdateAsync(UpdateMemberGoldReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberGoldRsp>();
    }

    private ISelect<Biz_MemberGold> QueryInternal(QueryReq<QueryMemberGoldReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}