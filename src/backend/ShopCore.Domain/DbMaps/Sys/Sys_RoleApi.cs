using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Sys;

/// <summary>
///     角色-接口映射表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Sys_RoleApi))]
public record Sys_RoleApi : ImmutableEntity
{
    /// <summary>
    ///     关联的接口
    /// </summary>
    [JsonIgnore]
    public Sys_Api Api { get; init; }

    /// <summary>
    ///     接口id
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    public string ApiId { get; init; }

    /// <summary>
    ///     关联的角色
    /// </summary>
    [JsonIgnore]
    public Sys_Role Role { get; init; }

    /// <summary>
    ///     角色id
    /// </summary>
    [JsonIgnore]
    public long RoleId { get; init; }
}