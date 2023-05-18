using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员金币模块
/// </summary>
public interface IMemberGoldModule : ICrudModule<CreateMemberGoldReq, QueryMemberGoldRsp, QueryMemberGoldReq,
    QueryMemberGoldRsp, UpdateMemberGoldReq, QueryMemberGoldRsp, DelReq> { }