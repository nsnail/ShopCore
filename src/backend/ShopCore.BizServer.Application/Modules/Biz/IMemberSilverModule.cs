using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberSilver;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员银币模块
/// </summary>
public interface IMemberSilverModule : ICrudModule<CreateMemberSilverReq, QueryMemberSilverRsp, QueryMemberSilverReq,
    QueryMemberSilverRsp, UpdateMemberSilverReq, QueryMemberSilverRsp, DelReq> { }