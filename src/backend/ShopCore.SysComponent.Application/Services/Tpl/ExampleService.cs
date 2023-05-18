using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.Domain.DbMaps.Tpl;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Tpl.Example;
using ShopCore.SysComponent.Application.Services.Tpl.Dependency;

namespace ShopCore.SysComponent.Application.Services.Tpl;

/// <inheritdoc cref="IExampleService" />
public sealed class ExampleService : RepositoryService<Tpl_Example, IExampleService>, IExampleService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ExampleService" /> class.
    /// </summary>
    public ExampleService(Repository<Tpl_Example> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除示例
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
    ///     创建示例
    /// </summary>
    public async Task<QueryExampleRsp> CreateAsync(CreateExampleReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryExampleRsp>();
    }

    /// <summary>
    ///     删除示例
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断示例是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryExampleReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个示例
    /// </summary>
    public async Task<QueryExampleRsp> GetAsync(QueryExampleReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryExampleReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryExampleRsp>();
    }

    /// <summary>
    ///     分页查询示例
    /// </summary>
    public async Task<PagedQueryRsp<QueryExampleRsp>> PagedQueryAsync(PagedQueryReq<QueryExampleReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryExampleRsp>(req.Page, req.PageSize, total
                                                , list.Adapt<IEnumerable<QueryExampleRsp>>());
    }

    /// <summary>
    ///     查询示例
    /// </summary>
    public async Task<IEnumerable<QueryExampleRsp>> QueryAsync(QueryReq<QueryExampleReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryExampleRsp>>();
    }

    /// <summary>
    ///     更新示例
    /// </summary>
    public async Task<QueryExampleRsp> UpdateAsync(UpdateExampleReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryExampleRsp>();
    }

    private ISelect<Tpl_Example> QueryInternal(QueryReq<QueryExampleReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}