using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.Domain.Dto.Biz.TokenWechat;

namespace ShopCore.BizServer.Application.Services.Biz.Dependency;

/// <summary>
///     微信令牌服务
/// </summary>
public interface ITokenWechatService : IService, ITokenWechatModule
{
    /// <summary>
    ///     获取单个微信令牌（使用openid）
    /// </summary>
    Task<QueryTokenWechatRsp> GetByOpenIdAsync(QueryTokenWechatReq req);
}