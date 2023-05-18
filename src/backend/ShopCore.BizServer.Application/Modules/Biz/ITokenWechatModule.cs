using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.TokenWechat;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     微信令牌模块
/// </summary>
public interface ITokenWechatModule : ICrudModule<CreateTokenWechatReq, QueryTokenWechatRsp, QueryTokenWechatReq,
    QueryTokenWechatRsp, UpdateTokenWechatReq, QueryTokenWechatRsp, DelReq> { }