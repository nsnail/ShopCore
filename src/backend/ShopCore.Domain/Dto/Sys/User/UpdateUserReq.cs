using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Sys.UserProfile;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：更新用户
/// </summary>
public sealed record UpdateUserReq : CreateUserReq
{
    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <summary>
    ///     此属性无意义，只是为了通过数据校验
    /// </summary>
    [JsonIgnore]
    public override string PasswordText => "MOCK-1234";

    /// <summary>
    ///     用户档案
    /// </summary>
    [Required]
    public new UpdateUserProfileReq Profile { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}