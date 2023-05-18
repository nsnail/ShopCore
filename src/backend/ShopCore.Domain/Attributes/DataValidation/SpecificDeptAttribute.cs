using ShopCore.Domain.Dto.Sys.Role;
using ShopCore.Domain.Enums.Sys;

namespace ShopCore.Domain.Attributes.DataValidation;

/// <summary>
///     数据范围为特定部门的验证器
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class SpecificDeptAttribute : ValidationAttribute
{
    /// <inheritdoc />
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (validationContext.ObjectInstance is not CreateRoleReq { DataScope: DataScopes.SpecificDept }) {
            return ValidationResult.Success;
        }
        #pragma warning disable IDE0046

        if ((value as IEnumerable<long>)?.Any() ?? false) {
            #pragma warning restore IDE0046
            return ValidationResult.Success;
        }

        return new ValidationResult(Ln.未指定部门);
    }
}