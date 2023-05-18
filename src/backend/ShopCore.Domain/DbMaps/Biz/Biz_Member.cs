using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Member))]
[Index($"idx_{{tablename}}_{nameof(Mobile)}",        nameof(Mobile),        true)]
[Index($"idx_{{tablename}}_{nameof(AlipayAccount)}", nameof(AlipayAccount), true)]
[Index($"idx_{{tablename}}_{nameof(Nick)}",          nameof(Nick),          true)]
public record Biz_Member : VersionEntity, IFieldEnabled
{
    /// <summary>
    ///     支付宝帐号
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string AlipayAccount { get; init; }

    /// <summary>
    ///     支付宝姓名
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR15)]
    [JsonIgnore]
    public string AlipayName { get; init; }

    /// <summary>
    ///     头像地址
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR127)]
    [JsonIgnore]
    public virtual string Avatar { get; set; }

    /// <summary>
    ///     封禁原因
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string BanReason { get; init; }

    /// <summary>
    ///     徒弟们
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(InviterId))]
    public IEnumerable<Biz_Member> Disciples { get; init; }

    /// <summary>
    ///     是否启用
    /// </summary>
    [Column]
    [JsonIgnore]
    public bool Enabled { get; init; }

    /// <summary>
    ///     已享受新人免单
    /// </summary>
    [Column]
    [JsonIgnore]
    public bool EnjoyedFreeShopping { get; init; }

    /// <summary>
    ///     固化信息
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(Id))]
    public Biz_MemberFixed Fixed { get; init; }

    /// <summary>
    ///     我的邀请码
    /// </summary>
    [Column]
    [JsonIgnore]
    public virtual int InviteCode { get; init; }

    /// <summary>
    ///     邀请者ID
    /// </summary>
    [Column]
    [JsonIgnore]
    public long? InviterId { get; init; }

    /// <summary>
    ///     用户等级
    /// </summary>
    [Column]
    [JsonIgnore]
    public MemberLevels Level { get; init; }

    /// <summary>
    ///     手机号
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR15)]
    [JsonIgnore]
    public virtual string Mobile { get; init; }

    /// <summary>
    ///     昵称
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public virtual string Nick { get; set; }

    /// <summary>
    ///     登录密码
    /// </summary>
    [Column]
    [JsonIgnore]
    public Guid PwdLogin { get; init; }

    /// <summary>
    ///     交易密码
    /// </summary>
    [Column]
    [JsonIgnore]
    public Guid PwdPay { get; init; }

    /// <summary>
    ///     已获得注册礼金
    /// </summary>
    [Column]
    [JsonIgnore]
    public bool RegBonus { get; init; }

    /// <summary>
    ///     如果此值变更用户登录将失效
    /// </summary>
    [Column]
    [JsonIgnore]
    public Guid SaltKey { get; init; }

    /// <summary>
    ///     用户
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(UserId))]
    public Sys_User User { get; init; }

    /// <summary>
    ///     用户编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long UserId { get; init; }

    /// <summary>
    ///     年卡会员
    /// </summary>
    [Column]
    [JsonIgnore]
    public bool Vip { get; init; }

    /// <summary>
    ///     钱包
    /// </summary>
    [JsonIgnore]
    [Navigate(nameof(Id))]
    public Biz_MemberWallet Wallet { get; init; }

    /// <summary>
    ///     微信号
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string Wechat { get; init; }
}