using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Address;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     地址模块
/// </summary>
public interface IAddressModule : ICrudModule<CreateAddressReq, QueryAddressRsp // 创建类型
  , QueryAddressReq, QueryAddressRsp                                            // 查询类型
  , UpdateAddressReq, QueryAddressRsp                                           // 修改类型
  , DelReq                                                                      // 删除类型
> { }