using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.Config;

/// <summary>
///     请求：创建配置
/// </summary>
public record CreateConfigReq : Sys_Config
{
    /// <inheritdoc cref="IFieldEnabled.Enabled" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool Enabled { get; init; }

    /// <inheritdoc cref="Sys_Config.UserRegisterConfirm" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool UserRegisterConfirm { get; set; }

    /// <inheritdoc cref="Sys_Config.UserRegisterDeptId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long UserRegisterDeptId { get; init; }

    /// <inheritdoc cref="Sys_Config.UserRegisterPosId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long UserRegisterPosId { get; init; }

    /// <inheritdoc cref="Sys_Config.UserRegisterRoleId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long UserRegisterRoleId { get; init; }
}