using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.User;

/// <summary>
///     请求：检查手机号是否可用
/// </summary>
public sealed record CheckMobileAvailableReq : Sys_User
{
    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Sys_User.Mobile" />
    [Mobile]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override string Mobile { get; init; }
}