using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Sys.Sms;
using ShopCore.Domain.Dto.Sys.UserProfile;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：注册用户
/// </summary>
public record RegisterReq : Sys_User, IRegister
{
    /// <summary>
    ///     密码
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.密码))]
    [Password]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public virtual string PasswordText { get; init; }

    /// <summary>
    ///     岗位编号列表
    /// </summary>
    [JsonIgnore]
    public IReadOnlyCollection<long> PositionIds { get; init; }

    /// <summary>
    ///     角色编号列表
    /// </summary>
    [JsonIgnore]
    public IReadOnlyCollection<long> RoleIds { get; init; }

    /// <summary>
    ///     用户名
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.用户名))]
    [UserName]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string UserName { get; init; }

    /// <summary>
    ///     短信验证请求
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.短信验证请求))]
    public VerifySmsCodeReq VerifySmsCodeReq { get; init; }

    /// <inheritdoc />
    public new void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<RegisterMemberReq, RegisterReq>() //
                  .Map(d => d.Profile, _ => new CreateUserProfileReq())
                  .Map(d => d.Enabled, _ => true)
                  .Map(d => d.Mobile,  s => s.VerifySmsCodeReq.DestMobile)
                  #pragma warning disable IDE0057
                  .Map( //
                      d => d.UserName, _ => string.Concat(Chars.FLG_SYSTEM_PREFIX, Guid.NewGuid().ToString().Substring(24)))
            #pragma warning restore IDE0057

            //
            ;
    }
}