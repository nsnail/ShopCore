using ShopCore.Application.Services;
using ShopCore.SysComponent.Application.Modules.Sys;

namespace ShopCore.SysComponent.Application.Services.Sys.Dependency;

/// <summary>
///     人机验证服务
/// </summary>
public interface ICaptchaService : IService, ICaptchaModule { }