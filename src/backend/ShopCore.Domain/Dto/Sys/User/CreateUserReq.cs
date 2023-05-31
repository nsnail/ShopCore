using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Sys.UserProfile;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：创建用户
/// </summary>
public record CreateUserReq : CreateUpdateUserReq
{
    /// <inheritdoc cref="CreateUpdateUserReq.PasswordText" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.密码))]
    public override string PasswordText { get; init; }

    /// <inheritdoc cref="Sys_User.Profile" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.用户档案))]
    public new CreateUserProfileReq Profile { get; init; }
}