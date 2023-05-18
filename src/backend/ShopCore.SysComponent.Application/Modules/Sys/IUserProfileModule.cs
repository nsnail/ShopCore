using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.UserProfile;

namespace ShopCore.SysComponent.Application.Modules.Sys;

/// <summary>
///     用户档案模块
/// </summary>
public interface IUserProfileModule : ICrudModule<CreateUserProfileReq, QueryUserProfileRsp // 创建类型
  , QueryUserProfileReq, QueryUserProfileRsp                                                // 查询类型
  , UpdateUserProfileReq, QueryUserProfileRsp                                               // 修改类型
  , DelReq                                                                                  // 删除类型
> { }