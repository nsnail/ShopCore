using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Order;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     订单模块
/// </summary>
public interface IOrderModule : ICrudModule<CreateOrderReq, QueryOrderRsp // 创建类型
  , QueryOrderReq, QueryOrderRsp                                          // 查询类型
  , UpdateOrderReq, QueryOrderRsp                                         // 修改类型
  , DelReq                                                                // 删除类型
> { }