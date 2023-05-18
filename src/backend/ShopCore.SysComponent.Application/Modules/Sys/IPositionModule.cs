using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Position;

namespace ShopCore.SysComponent.Application.Modules.Sys;

/// <summary>
///     岗位模块
/// </summary>
public interface IPositionModule : ICrudModule<CreatePositionReq, QueryPositionRsp // 创建类型
  , QueryPositionReq, QueryPositionRsp                                             // 查询类型
  , UpdatePositionReq, QueryPositionRsp                                            // 修改类型
  , DelReq                                                                         // 删除类型
> { }