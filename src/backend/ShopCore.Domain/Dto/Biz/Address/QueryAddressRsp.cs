using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.Address;

/// <summary>
///     响应：查询地址
/// </summary>
public sealed record QueryAddressRsp : Biz_Address
{
    /// <inheritdoc cref="Biz_Address.AreaAddress" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string AreaAddress { get; init; }

    /// <inheritdoc cref="Biz_Address.AreaId" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override int AreaId { get; init; }

    /// <inheritdoc cref="IFieldCreatedTime.CreatedTime" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override DateTime CreatedTime { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_Address.IsDefault" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool IsDefault { get; init; }

    /// <inheritdoc cref="Biz_Address.RecipientName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string RecipientName { get; init; }

    /// <inheritdoc cref="Biz_Address.RecipientPhone" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string RecipientPhone { get; init; }

    /// <inheritdoc cref="Biz_Address.StreetAddress" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string StreetAddress { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}