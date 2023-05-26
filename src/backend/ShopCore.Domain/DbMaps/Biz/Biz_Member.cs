using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Member))]
[Index($"idx_{{tablename}}_{nameof(Mobile)}",   nameof(Mobile),   true)]
[Index($"idx_{{tablename}}_{nameof(UserName)}", nameof(UserName), true)]
public record Biz_Member : VersionEntity, IFieldCreatedClient
{
    /// <summary>
    ///     头像链接
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    [JsonIgnore]
    public virtual string Avatar { get; init; }

    /// <summary>
    ///     余额
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long Balance { get; init; }

    /// <summary>
    ///     创建者客户端IP
    /// </summary>
    [Column(Position = -1)]
    [JsonIgnore]
    public virtual int? CreatedClientIp { get; init; }

    /// <summary>
    ///     创建者客户端用户代理
    /// </summary>
    [Column(Position = -1, DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    [JsonIgnore]
    public virtual string CreatedUserAgent { get; init; }

    /// <summary>
    ///     是否启用
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual bool Enabled { get; init; }

    /// <summary>
    ///     手机号
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_15)]
    [JsonIgnore]
    public virtual string Mobile { get; init; }

    /// <summary>
    ///     登录密码
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual Guid PwdLogin { get; init; }

    /// <summary>
    ///     交易密码
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual Guid PwdPay { get; init; }

    /// <summary>
    ///     注册者来源
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    [JsonIgnore]
    public virtual string RegisterSource { get; init; }

    /// <summary>
    ///     如果此值变更用户登录将失效
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual Guid SaltKey { get; init; }

    /// <summary>
    ///     系统用户
    /// </summary>
    [Column]
    [JsonIgnore]
    [Navigate(nameof(SysUser))]
    public virtual Sys_User SysUser { get; init; }

    /// <summary>
    ///     系统用户编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long SysUserId { get; init; }

    /// <summary>
    ///     用户名
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string UserName { get; init; }
}