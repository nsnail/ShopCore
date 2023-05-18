using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Sys.Sms;

/// <summary>
///     请求：更新短信
/// </summary>
public sealed record UpdateSmsReq : CreateSmsReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}