using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Tpl.Example;

namespace ShopCore.SysComponent.Application.Modules.Tpl;

/// <summary>
///     示例模块
/// </summary>
public interface IExampleModule : ICrudModule<CreateExampleReq, QueryExampleRsp // 创建类型
  , QueryExampleReq, QueryExampleRsp                                            // 查询类型
  , UpdateExampleReq, QueryExampleRsp                                           // 修改类型
  , DelReq                                                                      // 删除类型
> { }