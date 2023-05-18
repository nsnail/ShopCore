using ShopCore.Application.Services;
using ShopCore.Domain.Dto.Sys.Cache;
using ShopCore.SysComponent.Application.Modules.Sys;

namespace ShopCore.SysComponent.Application.Services.Sys.Dependency;

/// <summary>
///     缓存服务
/// </summary>
public interface ICacheService : IService, ICacheModule
{
    /// <summary>
    ///     获取所有缓存项
    /// </summary>
    IEnumerable<GetAllEntriesRsp> GetAllEntries();
}