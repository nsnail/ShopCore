namespace ShopCore.Domain.Attributes.DataValidation;

/// <summary>
///     密码验证器
/// </summary>
public sealed class PasswordAttribute : RegexAttribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PasswordAttribute" /> class.
    /// </summary>
    public PasswordAttribute() //
        : base(Chars.RGX_PASSWORD)
    {
        ErrorMessageResourceName = nameof(Ln._6位数字);
        ErrorMessageResourceType = typeof(Ln);
    }
}