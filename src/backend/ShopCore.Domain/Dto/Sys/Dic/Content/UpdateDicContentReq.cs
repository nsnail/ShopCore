using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Sys.Dic.Content;

/// <summary>
///     请求：更新字典内容
/// </summary>
public sealed record UpdateDicContentReq : CreateDicContentReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}