using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     响应：查询会员
/// </summary>
public sealed record QueryMemberRsp : Biz_Member
{
    /// <inheritdoc cref="Biz_Member.Avatar" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Avatar { get; init; }

    /// <inheritdoc cref="Biz_Member.Balance" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Balance { get; init; }

    /// <inheritdoc cref="IFieldCreatedTime.CreatedTime" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override DateTime CreatedTime { get; init; }

    /// <inheritdoc cref="Biz_Member.Enabled" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override bool Enabled { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_Member.Mobile" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Mobile { get; init; }

    /// <inheritdoc cref="Biz_Member.UserName" />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string UserName { get; init; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}