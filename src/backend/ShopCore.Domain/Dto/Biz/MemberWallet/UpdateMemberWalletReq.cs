using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.MemberWallet;

/// <summary>
///     请求：更新会员钱包
/// </summary>
public sealed record UpdateMemberWalletReq : CreateMemberWalletReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}