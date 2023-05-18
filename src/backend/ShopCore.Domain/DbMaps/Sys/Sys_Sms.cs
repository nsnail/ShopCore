using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.Enums.Sys;

namespace ShopCore.Domain.DbMaps.Sys;

/// <summary>
///     短信表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Sys_Sms))]
public record Sys_Sms : VersionEntity
{
    /// <summary>
    ///     验证码
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR7)]
    public virtual string Code { get; init; }

    /// <summary>
    ///     短信内容
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string Content { get; init; }

    /// <summary>
    ///     目的手机号
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR15)]
    public virtual string DestMobile { get; init; }

    /// <summary>
    ///     发送报告
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string Report { get; init; }

    /// <summary>
    ///     短信状态
    /// </summary>
    [JsonIgnore]
    public virtual SmsStatues Status { get; init; }

    /// <summary>
    ///     短信类型
    /// </summary>
    [JsonIgnore]
    public virtual SmsTypes Type { get; init; }
}