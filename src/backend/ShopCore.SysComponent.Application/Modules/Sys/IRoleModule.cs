using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Role;

namespace ShopCore.SysComponent.Application.Modules.Sys;

/// <summary>
///     角色模块
/// </summary>
public interface IRoleModule : ICrudModule<CreateRoleReq, QueryRoleRsp // 创建类型
  , QueryRoleReq, QueryRoleRsp                                         // 查询类型
  , UpdateRoleReq, QueryRoleRsp                                        // 修改类型
  , DelReq                                                             // 删除类型
> { }