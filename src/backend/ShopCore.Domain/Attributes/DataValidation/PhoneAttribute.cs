namespace ShopCore.Domain.Attributes.DataValidation;

/// <summary>
///     电话验证器（手机或固话）
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class PhoneAttribute : ValidationAttribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PhoneAttribute" /> class.
    /// </summary>
    public PhoneAttribute()
    {
        ErrorMessageResourceName = nameof(Ln.可用的手机号或座机号);
        ErrorMessageResourceType = typeof(Ln);
    }

    /// <inheritdoc />
    public override bool IsValid(object value)
    {
        return new MobileAttribute().IsValid(value) || new TelephoneAttribute().IsValid(value);
    }
}