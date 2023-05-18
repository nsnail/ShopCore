using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.TokenWechat;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     微信令牌服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class TokenWechatController : ControllerBase<ITokenWechatService>, ITokenWechatModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TokenWechatController" /> class.
    /// </summary>
    public TokenWechatController(ITokenWechatService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除微信令牌
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建微信令牌
    /// </summary>
    [Transaction]
    public Task<QueryTokenWechatRsp> CreateAsync(CreateTokenWechatReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除微信令牌
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     微信令牌是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryTokenWechatReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个微信令牌
    /// </summary>
    [NonAction]
    public Task<QueryTokenWechatRsp> GetAsync(QueryTokenWechatReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询微信令牌
    /// </summary>
    public Task<PagedQueryRsp<QueryTokenWechatRsp>> PagedQueryAsync(PagedQueryReq<QueryTokenWechatReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询微信令牌
    /// </summary>
    public Task<IEnumerable<QueryTokenWechatRsp>> QueryAsync(QueryReq<QueryTokenWechatReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     更新微信令牌
    /// </summary>
    [Transaction]
    public Task<QueryTokenWechatRsp> UpdateAsync(UpdateTokenWechatReq req)
    {
        return Service.UpdateAsync(req);
    }
}