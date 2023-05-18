using ShopCore.Cache;
using ShopCore.Domain.Dto.Sys.Captcha;
using ShopCore.SysComponent.Application.Modules.Sys;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.SysComponent.Cache.Sys;

/// <summary>
///     人机验证缓存接口
/// </summary>
public interface ICaptchaCache : ICache<IDistributedCache, ICaptchaService>, ICaptchaModule
{
    /// <summary>
    ///     完成人机校验 ，并删除缓存项
    /// </summary>
    Task VerifyCaptchaAndRemoveAsync(VerifyCaptchaReq req);
}