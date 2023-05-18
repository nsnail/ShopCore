using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.Config;

/// <summary>
///     请求：查询配置
/// </summary>
public sealed record QueryConfigReq : Sys_Config
{
    /// <summary>
    ///     是否启用
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public new bool? Enabled { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }
}