using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.MemberFixed;

/// <summary>
///     请求：更新会员固化信息
/// </summary>
public sealed record UpdateMemberFixedReq : CreateMemberFixedReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}