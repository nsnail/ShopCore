using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.TokenWechat;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="ITokenWechatService" />
public sealed class TokenWechatService : RepositoryService<Biz_TokenWechat, ITokenWechatService>, ITokenWechatService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TokenWechatService" /> class.
    /// </summary>
    public TokenWechatService(Repository<Biz_TokenWechat> rpo) //
        : base(rpo) { }

    /// <summary>
    ///     批量删除微信令牌
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
    ///     创建微信令牌
    /// </summary>
    public async Task<QueryTokenWechatRsp> CreateAsync(CreateTokenWechatReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryTokenWechatRsp>();
    }

    /// <summary>
    ///     删除微信令牌
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断微信令牌是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryTokenWechatReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个微信令牌
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryTokenWechatRsp> GetAsync(QueryTokenWechatReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个微信令牌（使用openid）
    /// </summary>
    public async Task<QueryTokenWechatRsp> GetByOpenIdAsync(QueryTokenWechatReq req)
    {
        return (await QueryInternal(new QueryReq<QueryTokenWechatReq> //
                                    {
                                        DynamicFilter = new DynamicFilterInfo {
                                                                                  Field    = nameof(req.OpenId)
                                                                                , Operator = DynamicFilterOperator.Eq
                                                                                , Value    = req.OpenId
                                                                              }
                                    })
            .ToOneAsync()).Adapt<QueryTokenWechatRsp>();
    }

    /// <summary>
    ///     分页查询微信令牌
    /// </summary>
    public async Task<PagedQueryRsp<QueryTokenWechatRsp>> PagedQueryAsync(PagedQueryReq<QueryTokenWechatReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryTokenWechatRsp>(req.Page, req.PageSize, total
                                                    , list.Adapt<IEnumerable<QueryTokenWechatRsp>>());
    }

    /// <summary>
    ///     查询微信令牌
    /// </summary>
    public async Task<IEnumerable<QueryTokenWechatRsp>> QueryAsync(QueryReq<QueryTokenWechatReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryTokenWechatRsp>>();
    }

    /// <summary>
    ///     更新微信令牌
    /// </summary>
    public async Task<QueryTokenWechatRsp> UpdateAsync(UpdateTokenWechatReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryTokenWechatRsp>();
    }

    private ISelect<Biz_TokenWechat> QueryInternal(QueryReq<QueryTokenWechatReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}