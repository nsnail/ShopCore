using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Modules.Biz;

namespace ShopCore.BizServer.Application.Services.Biz.Dependency;

/// <summary>
///     购物车服务
/// </summary>
public interface IShoppingCartService : IService, IShoppingCartModule { }