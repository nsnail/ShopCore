using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Dept;

namespace ShopCore.SysComponent.Application.Modules.Sys;

/// <summary>
///     部门模块
/// </summary>
public interface IDeptModule : ICrudModule<CreateDeptReq, QueryDeptRsp // 创建类型
  , QueryDeptReq, QueryDeptRsp                                         // 查询类型
  , UpdateDeptReq, QueryDeptRsp                                        // 修改类型
  , DelReq                                                             // 删除类型
> { }