using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：查询会员（使用邀请码）
/// </summary>
public record QueryMemberByInviteCodeReq : Biz_Member
{
    /// <summary>
    ///     我的邀请码
    /// </summary>
    [Required]
    [InviteCode]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int InviteCode { get; init; }
}