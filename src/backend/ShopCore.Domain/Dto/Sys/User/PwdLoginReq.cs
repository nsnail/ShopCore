using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：密码登录
/// </summary>
public record PwdLoginReq : DataAbstraction
{
    /// <summary>
    ///     用户名、手机号、邮箱
    /// </summary>
    [NotEmpty]
    public string Account { get; init; }

    /// <inheritdoc cref="Sys_User.Password" />
    [NotEmpty]
    public string Password { get; init; }
}