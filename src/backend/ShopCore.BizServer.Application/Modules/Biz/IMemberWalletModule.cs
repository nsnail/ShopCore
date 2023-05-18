using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberWallet;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员钱包模块
/// </summary>
public interface IMemberWalletModule : ICrudModule<CreateMemberWalletReq, QueryMemberWalletRsp, QueryMemberWalletReq,
    QueryMemberWalletRsp, UpdateMemberWalletReq, QueryMemberWalletRsp, DelReq> { }