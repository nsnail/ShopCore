using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Sys.Dic.Catalog;

/// <summary>
///     请求：更新字典目录
/// </summary>
public sealed record UpdateDicCatalogReq : CreateDicCatalogReq
{
    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}