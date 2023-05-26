using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：检查用户名是否可用
/// </summary>
public sealed record CheckMemberUserNameAvailableReq : Biz_Member
{
    /// <inheritdoc cref="Biz_Member.UserName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.用户名))]
    [UserName]
    public override string UserName { get; init; }
}