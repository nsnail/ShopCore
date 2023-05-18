using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Investment;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     投资模块
/// </summary>
public interface IInvestmentModule : ICrudModule<CreateInvestmentReq, QueryInvestmentRsp, QueryInvestmentReq,
    QueryInvestmentRsp, UpdateInvestmentReq, QueryInvestmentRsp, DelReq> { }