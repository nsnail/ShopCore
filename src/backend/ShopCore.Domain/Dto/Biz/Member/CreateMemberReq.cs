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
    /// <inheritdoc cref="Biz_Member.Mobile" />
    [CultureRequired]
    [Mobile]
    public override string Mobile { get; init; }

    /// <inheritdoc cref="Biz_Member.UserName" />
    [CultureRequired]
    [UserName]
    public override string UserName { get; init; }

    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        _ = config.ForType<RegisterRsp, CreateMemberReq>() //
                  .Map(d => d.Mobile,    s => s.Mobile)
                  .Map(d => d.Enabled,   s => s.Enabled)
                  .Map(d => d.Id,        _ => YitIdHelper.NextId())
                  .Map(d => d.SysUserId, s => s.Id)
                  .Map(d => d.SaltKey,   _ => Guid.NewGuid())

            //
            ;
    }
}