using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Address;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Dic.Content;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;
using DataType = FreeSql.DataType;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IAddressService" />
public sealed class AddressService : RepositoryService<Biz_Address, IAddressService>, IAddressService
{
    private readonly IDicService _dicService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressService" /> class.
    /// </summary>
    public AddressService(Repository<Biz_Address> rpo, IDicService dicService) //
        : base(rpo)
    {
        _dicService = dicService;
    }

    /// <summary>
    ///     批量删除地址
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
    ///     创建地址
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">地址区域编号不存在</exception>
    public async Task<QueryAddressRsp> CreateAsync(CreateAddressReq req)
    {
        var dynamicFilterInfos = new List<DynamicFilterInfo> {
                                                                 new() {
                                                                           Field = nameof(QueryDicContentReq.CatalogId)
                                                                         , Value = Numbers.DIC_CATALOG_ID_GEO_AREA
                                                                         , Operator = DynamicFilterOperator.Eq
                                                                       }
                                                               , new() {
                                                                           Field    = nameof(QueryDicContentReq.Value)
                                                                         , Value    = req.AreaId
                                                                         , Operator = DynamicFilterOperator.Eq
                                                                       }
                                                             };
        var area = (await _dicService.QueryContentAsync(
            new PagedQueryReq<QueryDicContentReq> {
                                                      DynamicFilter = new DynamicFilterInfo {
                                                                          Filters = dynamicFilterInfos
                                                                        , Logic   = DynamicFilterLogic.And
                                                                      }
                                                  })).FirstOrDefault();
        if (area == null) {
            throw new ShopCoreInvalidOperationException(Ln.地址区域编号不存在);
        }

        await UnsetDefaultAsync(req);
        var ret = await Rpo.InsertAsync(req with { AreaAddress = area.Key });

        return ret.Adapt<QueryAddressRsp>();
    }

    /// <summary>
    ///     删除地址
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断地址是否存在
    /// </summary>
    public Task<bool> ExistAsync(QueryReq<QueryAddressReq> req)
    {
        return QueryInternal(req).AnyAsync();
    }

    /// <summary>
    ///     获取单个地址
    /// </summary>
    public async Task<QueryAddressRsp> GetAsync(QueryAddressReq req)
    {
        var ret = await QueryInternal(new QueryReq<QueryAddressReq> { Filter = req }).ToOneAsync();
        return ret.Adapt<QueryAddressRsp>();
    }

    /// <summary>
    ///     分页查询地址
    /// </summary>
    public async Task<PagedQueryRsp<QueryAddressRsp>> PagedQueryAsync(PagedQueryReq<QueryAddressReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryAddressRsp>(req.Page, req.PageSize, total
                                                , list.Adapt<IEnumerable<QueryAddressRsp>>());
    }

    /// <summary>
    ///     查询地址
    /// </summary>
    public async Task<IEnumerable<QueryAddressRsp>> QueryAsync(QueryReq<QueryAddressReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryAddressRsp>>();
    }

    /// <summary>
    ///     更新地址
    /// </summary>
    public async Task<QueryAddressRsp> UpdateAsync(UpdateAddressReq req)
    {
        if (Rpo.Orm.Ado.DataType == DataType.Sqlite) {
            return await UpdateForSqliteAsync(req);
        }

        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryAddressRsp>();
    }

    private ISelect<Biz_Address> QueryInternal(QueryReq<QueryAddressReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.IsDefault)
                  .OrderByDescending(a => a.Id);
    }

    private async Task UnsetDefaultAsync(Biz_Address req)
    {
        if (req.IsDefault) {
            _ = await Rpo.UpdateDiy.Set(a => a.IsDefault, false)
                         .Set(a => a.ModifiedUserId,   UserToken.Id)
                         .Set(a => a.ModifiedUserName, UserToken.UserName)
                         .Where(a => a.IsDefault && a.MemberId == req.MemberId && a.Id != req.Id)
                         .ExecuteAffrowsAsync();
        }
    }

    /// <summary>
    ///     非sqlite数据库请删掉
    /// </summary>
    private async Task<QueryAddressRsp> UpdateForSqliteAsync(Biz_Address req)
    {
        if (await Rpo.UpdateDiy.SetSource(req).ExecuteAffrowsAsync() <= 0) {
            return null;
        }

        var ret = await Rpo.Select.Where(a => a.Id == req.Id).ToOneAsync();
        return ret.Adapt<QueryAddressRsp>();
    }
}