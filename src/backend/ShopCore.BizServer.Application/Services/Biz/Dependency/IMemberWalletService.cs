using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Biz.MemberWallet;

namespace ShopCore.BizServer.Application.Services.Biz.Dependency;

/// <summary>
///     会员钱包服务
/// </summary>
public interface IMemberWalletService : IService, IMemberWalletModule
{
    /// <summary>
    ///     交易金币
    /// </summary>
    Task ExchangeGoldAsync(ExchangeGoldReq req);

    /// <summary>
    ///     交易银币
    /// </summary>
    Task ExchangeSilverAsync(ExchangeSilverReq req);

    /// <summary>
    ///     获取单个钱包（带更新锁）
    /// </summary>
    Task<QueryMemberWalletRsp> GetForUpdateAsync(QueryMemberWalletReq req);
}