using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Dependency.Fields;
using ShopCore.Domain.Dto.Sys.User;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     响应：查询会员
/// </summary>
public sealed record QueryMemberRsp : Biz_Member
{
    /// <inheritdoc cref="Biz_Member.Balance" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Balance { get; init; }

    /// <inheritdoc cref="IFieldCreatedTime.CreatedTime" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override DateTime CreatedTime { get; init; }

    /// <inheritdoc cref="IFieldPrimary{T}.Id" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Id { get; init; }

    /// <inheritdoc cref="Biz_Member.SysUser" />
    public new QueryUserRsp SysUser { get; set; }

    /// <inheritdoc cref="IFieldVersion.Version" />
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public override long Version { get; init; }
}