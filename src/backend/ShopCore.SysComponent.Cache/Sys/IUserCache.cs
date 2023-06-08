using ShopCore.Cache;
using ShopCore.SysComponent.Application.Modules.Sys;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.SysComponent.Cache.Sys;

/// <summary>
///     用户缓存
/// </summary>
public interface IUserCache : ICache<IDistributedCache, IUserService>, IUserModule { }