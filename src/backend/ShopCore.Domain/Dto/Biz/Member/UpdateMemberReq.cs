using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：更新会员
/// </summary>
public sealed record UpdateMemberReq : CreateUpdateMemberReq, IRegister
{
    /// <inheritdoc cref="Biz_Member.SysUser" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.系统用户))]
    public new UpdateUserReq SysUser { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }

    /// <inheritdoc />
    public new void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<UpdateMemberReq, Biz_Member>() //
                  .Map(                                   //
                      d => d.PayPassword
                    , s => s.PayPasswordText.NullOrEmpty() ? Guid.Empty : s.PayPasswordText.Pwd().Guid())

            //
            ;
    }
}