using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Sys.Sms;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：注册用户
/// </summary>
public record RegisterReq : Sys_User
{
    /// <summary>
    ///     密码
    /// </summary>
    [NotEmpty]
    [Password]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public virtual string PasswordText { get; init; }

    /// <summary>
    ///     岗位id列表
    /// </summary>
    [JsonIgnore]
    public IReadOnlyCollection<long> PositionIds { get; init; }

    /// <summary>
    ///     角色id列表
    /// </summary>
    [JsonIgnore]
    public IReadOnlyCollection<long> RoleIds { get; init; }

    /// <summary>
    ///     用户名
    /// </summary>
    [NotEmpty]
    [UserName]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string UserName { get; init; }

    /// <summary>
    ///     短信验证请求
    /// </summary>
    [NotEmpty]
    public VerifySmsCodeReq VerifySmsCodeReq { get; init; }
}