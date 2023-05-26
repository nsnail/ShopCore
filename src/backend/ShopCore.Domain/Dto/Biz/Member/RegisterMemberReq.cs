using ShopCore.Domain.Dto.Sys.Sms;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：会员注册
/// </summary>
public sealed record RegisterMemberReq : RegisterReq, IRegister
{
    /// <summary>
    ///     密码
    /// </summary>
    [JsonIgnore]
    public override string PasswordText { get; init; } = Chars.FLG_RANDOM_UNAME_PWD;

    /// <summary>
    ///     用户名
    /// </summary>
    [JsonIgnore]
    public override string UserName { get; init; } = Chars.FLG_RANDOM_UNAME_PWD;

    /// <inheritdoc />
    public new void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<CreateMemberReq, RegisterMemberReq>() //
                  .Map(                                          //
                      d => d.VerifySmsCodeReq, s => new VerifySmsCodeReq { DestMobile = s.Mobile, Code = Global.SecretKey })

            //
            ;
    }
}