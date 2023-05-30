using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     会员模块
/// </summary>
public interface IMemberModule : ICrudModule<CreateMemberReq, QueryMemberRsp // 创建类型
  , QueryMemberReq, QueryMemberRsp                                           // 查询类型
  , UpdateMemberReq, QueryMemberRsp                                          // 修改类型
  , DelReq                                                                   // 删除类型
>
{
    /// <summary>
    ///     会员注册
    /// </summary>
    Task<QueryMemberRsp> RegisterAsync(RegisterMemberReq req);
}