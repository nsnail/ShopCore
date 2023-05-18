using ShopCore.Application.Services;
using ShopCore.Domain.Dto.Sys.User;
using ShopCore.SysComponent.Application.Modules.Sys;

namespace ShopCore.SysComponent.Application.Services.Sys.Dependency;

/// <summary>
///     用户服务
/// </summary>
public interface IUserService : IService, IUserModule
{
    /// <summary>
    ///     获取单个用户（带更新锁）
    /// </summary>
    Task<QueryUserRsp> GetForUpdateAsync(QueryUserReq req);

    /// <summary>
    ///     单体更新
    /// </summary>
    Task UpdateSingleAsync(UpdateUserReq req);
}