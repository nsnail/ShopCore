using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员变更表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_MemberChange))]
public record Biz_MemberChange : LiteImmutableEntity, IFieldCreatedClient
{
    /// <summary>
    ///     创建者客户端IP
    /// </summary>
    [Column(Position = -1)]
    public int? CreatedClientIp { get; init; }

    /// <summary>
    ///     创建者客户端用户代理
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255, Position = -1)]
    public string CreatedUserAgent { get; init; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    public long MemberId { get; set; }

    /// <summary>
    ///     变更类型
    /// </summary>
    [Column]
    public MemberChangeTypes Type { get; set; }

    /// <summary>
    ///     变更新值
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string ValueNew { get; set; }

    /// <summary>
    ///     变更前值
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string ValueOld { get; set; }
}