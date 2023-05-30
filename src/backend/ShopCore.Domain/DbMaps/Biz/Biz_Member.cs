using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Member))]
public record Biz_Member : VersionEntity, IFieldCreatedClient
{
    /// <summary>
    ///     账户余额
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
    ///     创建者来源地址
    /// </summary>
    [Column(Position = -1, DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    [JsonIgnore]
    public virtual string CreatedReferer { get; init; }

    /// <summary>
    ///     创建者客户端用户代理
    /// </summary>
    [Column(Position = -1, DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_255)]
    [JsonIgnore]
    public virtual string CreatedUserAgent { get; init; }

    /// <summary>
    ///     交易密码
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual Guid PayPassword { get; init; }

    /// <summary>
    ///     系统用户
    /// </summary>
    [Column]
    [JsonIgnore]
    [Navigate(nameof(SysUserId))]
    public virtual Sys_User SysUser { get; init; }

    /// <summary>
    ///     系统用户编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long SysUserId { get; init; }
}