using Microsoft.Data.SqlClient;
using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.UsedNumber;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IUsedNumberService" />
public sealed class UsedNumberService : RepositoryService<Biz_UsedNumber, IUsedNumberService>, IUsedNumberService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UsedNumberService" /> class.
    /// </summary>
    public UsedNumberService(Repository<Biz_UsedNumber> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除取号
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
    ///     创建取号
    /// </summary>
    public async Task<QueryUsedNumberRsp> CreateAsync(CreateUsedNumberReq req)
    {
        #pragma warning disable SA1002
        for (var i = 0;;) {
            #pragma warning restore SA1002
            var randNumber = new[] { req.Min, req.Max }.Rand();
            try {
                var ret = await Rpo.InsertAsync(new Biz_UsedNumber { Number = randNumber });
                return ret.Adapt<QueryUsedNumberRsp>();
            }
            catch (Exception ex) when (ex.InnerException is SqlException && ex.Message.Contains("duplicate key") &&
                                       i++ <= 10) {
                //
            }
        }
    }

    /// <summary>
    ///     删除取号
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断取号是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryUsedNumberReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个取号
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryUsedNumberRsp> GetAsync(QueryUsedNumberReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     分页查询取号
    /// </summary>
    public async Task<PagedQueryRsp<QueryUsedNumberRsp>> PagedQueryAsync(PagedQueryReq<QueryUsedNumberReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryUsedNumberRsp>(req.Page, req.PageSize, total
                                                   , list.Adapt<IEnumerable<QueryUsedNumberRsp>>());
    }

    /// <summary>
    ///     查询取号
    /// </summary>
    public async Task<IEnumerable<QueryUsedNumberRsp>> QueryAsync(QueryReq<QueryUsedNumberReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryUsedNumberRsp>>();
    }

    /// <summary>
    ///     更新取号
    /// </summary>
    public async Task<QueryUsedNumberRsp> UpdateAsync(UpdateUsedNumberReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryUsedNumberRsp>();
    }

    private ISelect<Biz_UsedNumber> QueryInternal(QueryReq<QueryUsedNumberReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}