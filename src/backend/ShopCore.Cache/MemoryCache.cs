using ShopCore.Application.Services;

namespace ShopCore.Cache;

/// <summary>
///     内存缓存
/// </summary>
public abstract class MemoryCache<TService> : CacheBase<IMemoryCache, TService>
    where TService : IService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemoryCache{TService}" /> class.
    /// </summary>
    protected MemoryCache(IMemoryCache cache, TService service) //
        : base(cache, service) { }
}