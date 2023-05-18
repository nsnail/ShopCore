using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员固化信息表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberFixed))]
public record Biz_MemberFixed : VersionEntity, IFieldCreatedClient
{
    /// <summary>
    ///     创建者客户端IP
    /// </summary>
    [Column(Position = -1)]
    public int? CreatedClientIp { get; init; }

    /// <summary>
    ///     创建者客户端用户代理
    /// </summary>
    [Column(Position = -1, DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string CreatedUserAgent { get; init; }

    /// <summary>
    ///     会员
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(Id))]
    public Biz_Member Member { get; init; }

    /// <summary>
    ///     注册者来源
    /// </summary>
    [JsonIgnore]
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR1022)]
    public string RegisterSource { get; set; }
}