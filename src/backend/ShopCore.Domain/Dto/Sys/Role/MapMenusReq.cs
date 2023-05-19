using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Sys.Role;

/// <summary>
///     请求：角色-菜单映射
/// </summary>
public sealed record MapMenusReq : DataAbstraction
{
    /// <summary>
    ///     菜单id
    /// </summary>
    [NotEmpty]
    public IReadOnlyCollection<long> MenuIds { get; init; }

    /// <summary>
    ///     角色id
    /// </summary>
    [NotEmpty]
    public long RoleId { get; init; }
}