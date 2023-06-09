using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     地址表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Address))]
public record Biz_Address : VersionEntity, IFieldOwner
{
    /// <summary>
    ///     区域地址
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    [JsonIgnore]
    public virtual string AreaAddress { get; init; }

    /// <summary>
    ///     区域编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int AreaId { get; init; }

    /// <summary>
    ///     是否默认地址
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual bool IsDefault { get; init; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual long MemberId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerDeptId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public virtual long? OwnerDeptId { get; init; }

    /// <inheritdoc cref="IFieldOwner.OwnerId" />
    [Column(Position = -1)]
    [JsonIgnore]
    public virtual long? OwnerId { get; init; }

    /// <summary>
    ///     收件人姓名
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string RecipientName { get; init; }

    /// <summary>
    ///     收件人电话
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string RecipientPhone { get; init; }

    /// <summary>
    ///     街道地址
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    [JsonIgnore]
    public virtual string StreetAddress { get; init; }
}