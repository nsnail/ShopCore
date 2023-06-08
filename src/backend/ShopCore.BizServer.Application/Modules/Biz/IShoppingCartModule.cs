using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.ShoppingCart;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     购物车模块
/// </summary>
public interface IShoppingCartModule : ICrudModule<CreateShoppingCartReq, QueryShoppingCartRsp // 创建类型
  , QueryShoppingCartReq, QueryShoppingCartRsp                                                 // 查询类型
  , UpdateShoppingCartReq, QueryShoppingCartRsp                                                // 修改类型
  , DelReq                                                                                     // 删除类型
> { }