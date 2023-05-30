using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：会员注册
/// </summary>
public sealed record RegisterMemberReq : Biz_Member
{
    /// <inheritdoc cref="Biz_Member.SysUser" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.系统用户))]
    public new RegisterReq SysUser { get; init; }
}