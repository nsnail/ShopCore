using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.MemberInvestment;

/// <summary>
///     请求：更新会员投资
/// </summary>
public sealed record UpdateMemberInvestmentReq : CreateMemberInvestmentReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}