using ShopCore.Domain.DbMaps.Dependency;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Biz.Member;

namespace ShopCore.Domain.DbMaps.Biz;

/// <summary>
///     会员表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Biz_Member))]
public record Biz_Member : VersionEntity, IFieldCreatedClient, IRegister
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
    public Guid PayPassword { get; init; }

    /// <summary>
    ///     系统用户
    /// </summary>
    [Column]
    [JsonIgnore]
    [Navigate(nameof(SysUserId))]
    public Sys_User SysUser { get; init; }

    /// <summary>
    ///     系统用户编号
    /// </summary>
    [Column]
    [JsonIgnore]
    public long SysUserId { get; init; }

    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<RegisterMemberReq, Biz_Member>() //
                  .Map(d => d.PayPassword, s => s.PayPasswordText.Pwd().Guid())

            //
            ;

        _ = config.ForType<UpdateMemberReq, Biz_Member>() //
                  .Map(                                   //
                      d => d.PayPassword
                    , s => s.PayPasswordText.NullOrEmpty() ? Guid.Empty : s.PayPasswordText.Pwd().Guid())

            //
            ;
    }
}