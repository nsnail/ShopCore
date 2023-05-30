using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：更新会员
/// </summary>
public sealed record UpdateMemberReq : CreateMemberReq
{
    /// <inheritdoc cref="Biz_Member.SysUser" />
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.系统用户))]
    public new UpdateUserReq SysUser { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}