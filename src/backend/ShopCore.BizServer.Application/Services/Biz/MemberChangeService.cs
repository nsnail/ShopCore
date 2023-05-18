using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.MemberChange;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberChangeService" />
public sealed class MemberChangeService : RepositoryService<Biz_MemberChange, IMemberChangeService>
                                        , IMemberChangeService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberChangeService" /> class.
    /// </summary>
    public MemberChangeService(Repository<Biz_MemberChange> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除会员变更
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
    ///     创建会员变更
    /// </summary>
    public async Task<QueryMemberChangeRsp> CreateAsync(CreateMemberChangeReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberChangeRsp>();
    }

    /// <summary>
    ///     删除会员变更
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员变更是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryMemberChangeReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个会员变更
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberChangeRsp> GetAsync(QueryMemberChangeReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询会员变更
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberChangeRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberChangeReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberChangeRsp>(req.Page, req.PageSize, total
                                                     , list.Adapt<IEnumerable<QueryMemberChangeRsp>>());
    }

    /// <summary>
    ///     查询会员变更
    /// </summary>
    public async Task<IEnumerable<QueryMemberChangeRsp>> QueryAsync(QueryReq<QueryMemberChangeReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberChangeRsp>>();
    }

    /// <summary>
    ///     更新会员变更
    /// </summary>
    public async Task<QueryMemberChangeRsp> UpdateAsync(UpdateMemberChangeReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberChangeRsp>();
    }

    private ISelect<Biz_MemberChange> QueryInternal(QueryReq<QueryMemberChangeReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}