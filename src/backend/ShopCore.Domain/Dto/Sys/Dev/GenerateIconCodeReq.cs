using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Sys.Dev;

/// <summary>
///     请求：生成图标代码
/// </summary>
public sealed record GenerateIconCodeReq : DataAbstraction
{
    /// <summary>
    ///     图标名称
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.图标名称))]
    public string IconName { get; init; }

    /// <summary>
    ///     图标代码
    /// </summary>
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.图标代码))]
    public string SvgCode { get; init; }
}