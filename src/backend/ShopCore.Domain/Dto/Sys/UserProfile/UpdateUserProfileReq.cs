using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Sys.UserProfile;

/// <summary>
///     请求：更新用户档案
/// </summary>
public sealed record UpdateUserProfileReq : CreateUserProfileReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}