using ShopCore.Domain.Attributes.DataValidation;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Address;

/// <summary>
///     请求：创建地址
/// </summary>
public record CreateAddressReq : Biz_Address
{
    /// <inheritdoc cref="Biz_Address.AreaId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int AreaId { get; init; }

    /// <inheritdoc cref="Biz_Address.IsDefault" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool IsDefault { get; init; }

    /// <inheritdoc cref="Biz_Address.MemberId" />
    [JsonIgnore]
    public override long MemberId { get; init; } = App.GetService<ContextMemberInfo>().Id;

    /// <inheritdoc cref="Biz_Address.RecipientName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.收件人姓名))]
    public override string RecipientName { get; init; }

    /// <inheritdoc cref="Biz_Address.RecipientPhone" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CulturePhone]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.收件人电话))]
    public override string RecipientPhone { get; init; }

    /// <inheritdoc cref="Biz_Address.StreetAddress" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CultureRequired(ErrorMessageResourceType = typeof(Ln), ErrorMessageResourceName = nameof(Ln.街道地址))]
    public override string StreetAddress { get; init; }
}