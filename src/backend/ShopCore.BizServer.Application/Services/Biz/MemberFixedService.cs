using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.MemberFixed;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberFixedService" />
public sealed class MemberFixedService : RepositoryService<Biz_MemberFixed, IMemberFixedService>, IMemberFixedService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberFixedService" /> class.
    /// </summary>
    public MemberFixedService(Repository<Biz_MemberFixed> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除会员固化信息
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
    ///     创建会员固化信息
    /// </summary>
    public async Task<QueryMemberFixedRsp> CreateAsync(CreateMemberFixedReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberFixedRsp>();
    }

    /// <summary>
    ///     删除会员固化信息
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员固化是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberFixedReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员固化
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberFixedRsp> GetAsync(QueryMemberFixedReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询会员固化信息
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberFixedRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberFixedReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberFixedRsp>(req.Page, req.PageSize, total
                                                    , list.Adapt<IEnumerable<QueryMemberFixedRsp>>());
    }

    /// <summary>
    ///     查询会员固化信息
    /// </summary>
    public async Task<IEnumerable<QueryMemberFixedRsp>> QueryAsync(QueryReq<QueryMemberFixedReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberFixedRsp>>();
    }

    /// <summary>
    ///     更新会员固化信息
    /// </summary>
    public async Task<QueryMemberFixedRsp> UpdateAsync(UpdateMemberFixedReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberFixedRsp>();
    }

    private ISelect<Biz_MemberFixed> QueryInternal(QueryReq<QueryMemberFixedReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}