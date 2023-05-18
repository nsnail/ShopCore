using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Sys.UserProfile;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：创建用户
/// </summary>
public record CreateUserReq : Sys_User
{
    /// <inheritdoc cref="Sys_User.Avatar" />
    [Url]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string Avatar { get; init; }

    /// <inheritdoc cref="Sys_User.DeptId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long DeptId { get; init; }

    /// <inheritdoc cref="Sys_User.Email" />
    [EmailAddress]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string Email { get; init; }

    /// <inheritdoc cref="IFieldEnabled.Enabled" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool Enabled { get; init; }

    /// <inheritdoc cref="Sys_User.Mobile" />
    [Mobile]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string Mobile { get; init; }

    /// <summary>
    ///     密码
    /// </summary>
    [Required]
    [Password]
    public virtual string PasswordText { get; init; }

    /// <summary>
    ///     岗位id列表
    /// </summary>
    [Required]
    [MinLength(1)]
    [MaxLength(Numbers.BULK_REQ_LIMIT)]
    public IReadOnlyCollection<long> PositionIds { get; init; }

    /// <summary>
    ///     用户档案
    /// </summary>
    [Required]
    public new CreateUserProfileReq Profile { get; init; }

    /// <summary>
    ///     角色id列表
    /// </summary>
    [Required]
    [MinLength(1)]
    [MaxLength(Numbers.BULK_REQ_LIMIT)]
    public IReadOnlyCollection<long> RoleIds { get; init; }

    /// <inheritdoc cref="Sys_User.UserName" />
    [Required]
    [UserName]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string UserName { get; init; }
}