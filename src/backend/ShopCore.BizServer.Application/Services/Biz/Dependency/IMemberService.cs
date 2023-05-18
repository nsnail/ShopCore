using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.Domain.Dto.Biz.Member;

namespace ShopCore.BizServer.Application.Services.Biz.Dependency;

/// <summary>
///     会员服务
/// </summary>
public interface IMemberService : IService, IMemberModule
{
    /// <summary>
    ///     检查支付宝账号是否可用
    /// </summary>
    Task<bool> CheckAlipayAvailableAsync(CheckAlipayAvailableReq req);

    /// <summary>
    ///     获取单个会员（带更新锁）
    /// </summary>
    Task<QueryMemberRsp> GetForUpdateAsync(QueryMemberReq req);
}