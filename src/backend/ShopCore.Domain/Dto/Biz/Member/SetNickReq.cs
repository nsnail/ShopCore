using ShopCore.Domain.Attributes.DataValidation;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     请求：设置昵称
/// </summary>
public record SetNickReq : DataAbstraction
{
    /// <summary>
    ///     昵称
    /// </summary>
    [Required]
    [UserName]
    public string Nick { get; init; }
}