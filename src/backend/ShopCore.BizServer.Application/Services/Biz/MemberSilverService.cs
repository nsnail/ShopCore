using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.MemberSilver;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberSilverService" />
public sealed class MemberSilverService : RepositoryService<Biz_MemberSilver, IMemberSilverService>
                                        , IMemberSilverService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberSilverService" /> class.
    /// </summary>
    public MemberSilverService(Repository<Biz_MemberSilver> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除会员银币
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
    ///     创建会员银币
    /// </summary>
    public async Task<QueryMemberSilverRsp> CreateAsync(CreateMemberSilverReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberSilverRsp>();
    }

    /// <summary>
    ///     删除会员银币
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员银币是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberSilverReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员银币
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberSilverRsp> GetAsync(QueryMemberSilverReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询会员银币
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberSilverRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberSilverReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberSilverRsp>(req.Page, req.PageSize, total
                                                     , list.Adapt<IEnumerable<QueryMemberSilverRsp>>());
    }

    /// <summary>
    ///     查询会员银币
    /// </summary>
    public async Task<IEnumerable<QueryMemberSilverRsp>> QueryAsync(QueryReq<QueryMemberSilverReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberSilverRsp>>();
    }

    /// <summary>
    ///     更新会员银币
    /// </summary>
    public async Task<QueryMemberSilverRsp> UpdateAsync(UpdateMemberSilverReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberSilverRsp>();
    }

    private ISelect<Biz_MemberSilver> QueryInternal(QueryReq<QueryMemberSilverReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}