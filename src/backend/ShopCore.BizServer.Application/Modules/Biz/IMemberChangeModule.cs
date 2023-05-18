using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.MemberChange;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员变更模块
/// </summary>
public interface IMemberChangeModule : ICrudModule<CreateMemberChangeReq, QueryMemberChangeRsp // 创建类型
  , QueryMemberChangeReq, QueryMemberChangeRsp                                                 // 查询类型
  , UpdateMemberChangeReq, QueryMemberChangeRsp                                                // 修改类型
  , DelReq                                                                                     // 删除类型
> { }