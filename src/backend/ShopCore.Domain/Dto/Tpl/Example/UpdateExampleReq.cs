using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Tpl.Example;

/// <summary>
///     请求：更新示例
/// </summary>
public sealed record UpdateExampleReq : CreateExampleReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}