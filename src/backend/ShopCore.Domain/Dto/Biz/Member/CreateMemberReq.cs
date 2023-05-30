using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Sys.User;
using Yitter.IdGenerator;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：创建会员
/// </summary>
public record CreateMemberReq : Biz_Member, IRegister
{
    /// <inheritdoc cref="Biz_Member.SysUser" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.系统用户))]
    public new CreateUserReq SysUser { get; init; }

    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<QueryUserRsp, CreateMemberReq>() //
                  .Map(d => d.Id,        _ => YitIdHelper.NextId())
                  .Map(d => d.SysUserId, s => s.Id)

            //
            ;
    }
}