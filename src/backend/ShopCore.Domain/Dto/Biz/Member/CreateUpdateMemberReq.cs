using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：创建更新会员
/// </summary>
public abstract record CreateUpdateMemberReq : Biz_Member
{
    /// <summary>
    ///     交易密码
    /// </summary>
    [PayPassword]
    public virtual string PayPasswordText { get; init; }
}