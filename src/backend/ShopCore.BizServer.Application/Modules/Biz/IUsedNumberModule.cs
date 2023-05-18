using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.UsedNumber;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     取号模块
/// </summary>
public interface IUsedNumberModule : ICrudModule<CreateUsedNumberReq, QueryUsedNumberRsp, QueryUsedNumberReq,
    QueryUsedNumberRsp, UpdateUsedNumberReq, QueryUsedNumberRsp, DelReq> { }