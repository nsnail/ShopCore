using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.MemberSilver;

/// <summary>
///     请求：查询会员银币
/// </summary>
public sealed record QueryMemberSilverReq : Biz_MemberSilver
{
    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }
}