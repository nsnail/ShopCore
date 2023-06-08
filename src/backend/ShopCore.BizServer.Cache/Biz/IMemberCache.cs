using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Cache;

namespace ShopCore.BizServer.Cache.Biz;

/// <summary>
///     会员缓存
/// </summary>
public interface IMemberCache : ICache<IDistributedCache, IMemberService>, IMemberModule { }