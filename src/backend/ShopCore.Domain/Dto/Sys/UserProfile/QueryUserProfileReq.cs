using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.UserProfile;

/// <summary>
///     请求：查询用户档案
/// </summary>
public sealed record QueryUserProfileReq : Sys_UserProfile
{
    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }
}