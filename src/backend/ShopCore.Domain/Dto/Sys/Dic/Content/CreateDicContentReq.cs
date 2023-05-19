using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.Dic.Content;

/// <summary>
///     请求：创建字典内容
/// </summary>
public record CreateDicContentReq : Sys_DicContent
{
    /// <inheritdoc cref="Sys_DicContent.CatalogId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [NotEmpty]
    public override long CatalogId { get; init; }

    /// <inheritdoc cref="Sys_DicContent.Key" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [NotEmpty]
    public override string Key { get; init; }

    /// <inheritdoc cref="Sys_DicContent.Value" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [NotEmpty]
    public override string Value { get; init; }
}