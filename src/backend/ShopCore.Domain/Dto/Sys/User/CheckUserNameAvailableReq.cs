using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：检查用户名是否可用
/// </summary>
public sealed record CheckUserNameAvailableReq : Sys_User
{
    /// <inheritdoc cref="Sys_User.UserName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [NotEmpty]
    [UserName]
    public override string UserName { get; init; }
}