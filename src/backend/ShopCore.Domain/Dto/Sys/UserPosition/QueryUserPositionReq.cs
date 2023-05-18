using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.UserPosition;

/// <summary>
///     请求：查询用户-岗位映射
/// </summary>
public sealed record QueryUserPositionReq : Sys_UserPosition
{
    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }
}