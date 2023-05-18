namespace ShopCore.Domain.Attributes.DataValidation;

/// <summary>
///     手机号验证器
/// </summary>
public sealed class MobileAttribute : RegexAttribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MobileAttribute" /> class.
    /// </summary>
    public MobileAttribute() //
        : base(Chars.RGX_MOBILE)
    {
        ErrorMessageResourceName = nameof(Ln.您正在使用的手机号码);
        ErrorMessageResourceType = typeof(Ln);
    }
}