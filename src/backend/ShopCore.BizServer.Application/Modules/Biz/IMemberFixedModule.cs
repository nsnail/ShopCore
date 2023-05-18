using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberFixed;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员固化信息模块
/// </summary>
public interface IMemberFixedModule : ICrudModule<CreateMemberFixedReq, QueryMemberFixedRsp, QueryMemberFixedReq,
    QueryMemberFixedRsp, UpdateMemberFixedReq, QueryMemberFixedRsp, DelReq> { }