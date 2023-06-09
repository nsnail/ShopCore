using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.OrderItem;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     订单项模块
/// </summary>
public interface IOrderItemModule : ICrudModule<CreateOrderItemReq, QueryOrderItemRsp // 创建类型
  , QueryOrderItemReq, QueryOrderItemRsp                                              // 查询类型
  , UpdateOrderItemReq, QueryOrderItemRsp                                             // 修改类型
  , DelReq                                                                            // 删除类型
> { }