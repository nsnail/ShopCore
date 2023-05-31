using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Sys.Role;
using ShopCore.Domain.Enums.Sys;

namespace ShopCore.Domain.DbMaps.Sys;

/// <summary>
///     角色表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Sys_Role))]
[Index("idx_{tablename}_01", nameof(Name), true)]
public record Sys_Role : VersionEntity, IFieldSort, IFieldSummary, IRegister
{
    /// <summary>
    ///     角色-接口映射
    /// </summary>
    [JsonIgnore]
    [Navigate(ManyToMany = typeof(Sys_RoleApi))]
    public virtual ICollection<Sys_Api> Apis { get; init; }

    /// <summary>
    ///     数据范围
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual DataScopes DataScope { get; init; }

    /// <summary>
    ///     角色-部门映射
    /// </summary>
    [JsonIgnore]
    [Navigate(ManyToMany = typeof(Sys_RoleDept))]
    public virtual ICollection<Sys_Dept> Depts { get; init; }

    /// <summary>
    ///     是否显示仪表板
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual bool DisplayDashboard { get; init; }

    /// <summary>
    ///     是否忽略权限控制
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual bool IgnorePermissionControl { get; init; }

    /// <summary>
    ///     角色-菜单映射
    /// </summary>
    [JsonIgnore]
    [Navigate(ManyToMany = typeof(Sys_RoleMenu))]
    public virtual ICollection<Sys_Menu> Menus { get; init; }

    /// <summary>
    ///     角色名称
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    public virtual string Name { get; init; }

    /// <summary>
    ///     排序值，越大越前
    /// </summary>
    [JsonIgnore]
    [Column]
    public virtual long Sort { get; init; }

    /// <summary>
    ///     备注
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    public virtual string Summary { get; init; }

    /// <summary>
    ///     此角色下的用户集合
    /// </summary>
    [JsonIgnore]
    [Navigate(ManyToMany = typeof(Sys_UserRole))]
    public virtual ICollection<Sys_User> Users { get; init; }

    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<CreateRoleReq, Sys_Role>()
                  .Map( //
                      d => d.Depts
                    , s => s.DeptIds.NullOrEmpty()
                          ? Array.Empty<Sys_Dept>()
                          : s.DeptIds.Select(x => new Sys_Dept { Id = x }))
                  .Map( //
                      d => d.Menus
                    , s => s.MenuIds.NullOrEmpty()
                          ? Array.Empty<Sys_Menu>()
                          : s.MenuIds.Select(x => new Sys_Menu { Id = x }))
                  .Map( //
                      d => d.Apis
                    , s => s.ApiIds.NullOrEmpty()
                          ? Array.Empty<Sys_Api>()
                          : s.ApiIds.Select(x => new Sys_Api { Id = x }))

            //
            ;
    }
}