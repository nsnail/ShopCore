using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     订单表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Order))]
public record Biz_Order : VersionEntity, IFieldOwner, IFieldSummary
{
    /// <summary>
    ///     区域编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int AreaId { get; set; }

    /// <summary>
    ///     订单项
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(Biz_OrderItem.OrderId))]
    public virtual ICollection<Biz_OrderItem> Items { get; init; }

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
    ///     支付方式
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual PayModes? PayMode { get; init; }

    /// <summary>
    ///     收件人姓名
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string RecipientName { get; set; }

    /// <summary>
    ///     收件人电话
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_31)]
    [JsonIgnore]
    public virtual string RecipientPhone { get; set; }

    /// <summary>
    ///     订单状态
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual OrderStatues Status { get; set; }

    /// <summary>
    ///     街道地址
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_127)]
    [JsonIgnore]
    public virtual string StreetAddress { get; set; }

    /// <inheritdoc cref="IFieldSummary.Summary" />
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR_63)]
    [JsonIgnore]
    public virtual string Summary { get; init; }

    /// <summary>
    ///     总金额
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int TotalAmount { get; set; }
}