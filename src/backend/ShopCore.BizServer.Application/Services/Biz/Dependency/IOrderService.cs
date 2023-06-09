using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Modules.Biz;

namespace ShopCore.BizServer.Application.Services.Biz.Dependency;

/// <summary>
///     订单服务
/// </summary>
public interface IOrderService : IService, IOrderModule { }