using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     微信令牌表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_TokenWechat))]
[Index($"idx_{{tablename}}_{nameof(OpenId)}", nameof(OpenId), true)]
public record Biz_TokenWechat : VersionEntity
{
    /// <summary>
    ///     Access Token
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    public string AccessToken { get; set; }

    /// <summary>
    ///     普通用户个人资料填写的城市
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string City { get; set; }

    /// <summary>
    ///     国家，如中国为 CN
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR7)]
    [JsonIgnore]
    public string Country { get; set; }

    /// <summary>
    ///     Access Token 过期时间
    /// </summary>
    [Column]
    [JsonIgnore]
    public DateTime ExpiresIn { get; set; }

    /// <summary>
    ///     用户头像，最后一个数值代表正方形头像大小（有 0、46、64、96、132 数值可选，0 代表 640*640 正方形头像），用户没有头像时该项为空
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR127)]
    [JsonIgnore]
    public string HeadImgUrl { get; set; }

    /// <summary>
    ///     语言
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR15)]
    [JsonIgnore]
    public string Language { get; set; }

    /// <summary>
    ///     会员编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long? MemberId { get; set; }

    /// <summary>
    ///     普通用户昵称
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string NickName { get; set; }

    /// <summary>
    ///     普通用户的标识，对当前开发者帐号唯一
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string OpenId { get; init; }

    /// <summary>
    ///     普通用户个人资料填写的省份
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR15)]
    [JsonIgnore]
    public string Province { get; set; }

    /// <summary>
    ///     Refresh Token
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR255)]
    [JsonIgnore]
    public string RefreshToken { get; set; }

    /// <summary>
    ///     Scope作用域
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string Scope { get; set; }

    /// <summary>
    ///     普通用户性别，1 为男性，2 为女性
    /// </summary>
    [Column]
    [JsonIgnore]
    public int? Sex { get; set; }

    /// <summary>
    ///     用户统一标识。针对一个微信开放平台帐号下的应用，同一用户的 unionid 是唯一的。
    /// </summary>
    [Column(DbType = Chars.FLG_DB_FIELD_TYPE_VARCHAR31)]
    [JsonIgnore]
    public string UnionId { get; set; }
}