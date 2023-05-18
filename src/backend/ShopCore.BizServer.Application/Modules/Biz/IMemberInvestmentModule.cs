using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberInvestment;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员投资模块
/// </summary>
public interface IMemberInvestmentModule : ICrudModule<CreateMemberInvestmentReq, QueryMemberInvestmentRsp,
    QueryMemberInvestmentReq, QueryMemberInvestmentRsp, UpdateMemberInvestmentReq, QueryMemberInvestmentRsp, DelReq> { }