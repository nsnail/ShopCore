using ShopCore.Domain.DbMaps.Dependency;

namespace ShopCore.Domain.DbMaps.Tpl;

/// <summary>
///     示例表
/// </summary>
[Table(Name = Chars.FLG_TABLE_NAME_PREFIX + nameof(Tpl_Example))]
public record Tpl_Example : VersionEntity;