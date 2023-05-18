using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.Dic.Content;

namespace ShopCore.SysComponent.Application.Modules.Sys;

/// <summary>
///     字典内容模块
/// </summary>
public interface IDicContentModule : ICrudModule<CreateDicContentReq, QueryDicContentRsp // 创建类型
  , QueryDicContentReq, QueryDicContentRsp                                               // 查询类型
  , UpdateDicContentReq, QueryDicContentRsp                                              // 修改类型
  , DelReq                                                                               // 删除类型
> { }