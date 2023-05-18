using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Sys;

/// <summary>
///     部门表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Sys_Dept))]
public record Sys_Dept : VersionEntity, IFieldSummary, IFieldSort
{
    /// <summary>
    ///     子节点
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(ParentId))]
    public IEnumerable<Sys_Dept> Children { get; init; }

    /// <summary>
    ///     部门名称
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    public virtual string Name { get; init; }

    /// <summary>
    ///     父id
    /// </summary>
    [JsonIgnore]
    public virtual long ParentId { get; init; }

    /// <summary>
    ///     角色集合
    /// </summary>
    [JsonIgnore]
    [Navigate(ManyToMany = typeof(Sys_RoleDept))]
    public ICollection<Sys_Role> Roles { get; init; }

    /// <summary>
    ///     排序值，越大越前
    /// </summary>
    [JsonIgnore]
    public virtual long Sort { get; init; } = Numbers.DEF_SORT_VAL;

    /// <summary>
    ///     部门描述
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public virtual string Summary { get; init; }
}