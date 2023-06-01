using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Sys;

/// <summary>
///     用户-岗位映射表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Sys_UserPosition))]
public record Sys_UserPosition : ImmutableEntity
{
    /// <summary>
    ///     关联的岗位
    /// </summary>
    [JsonIgnore]
    public Sys_Position Position { get; init; }

    /// <summary>
    ///     岗位编号
    /// </summary>
    [JsonIgnore]
    [Column]
    public long PositionId { get; init; }

    /// <summary>
    ///     关联的用户
    /// </summary>
    [JsonIgnore]
    public Sys_User User { get; init; }

    /// <summary>
    ///     用户编号
    /// </summary>
    [JsonIgnore]
    [Column]
    public long UserId { get; init; }
}