using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.TokenWechat;

/// <summary>
///     请求：更新微信令牌
/// </summary>
public sealed record UpdateTokenWechatReq : CreateTokenWechatReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}