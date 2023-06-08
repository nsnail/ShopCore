using ShopCore.Domain.Dto.Biz.Member;

namespace ShopCore.Domain.Contexts;

/// <summary>
///     上下文会员信息
/// </summary>
public sealed record ContextMemberInfo : QueryMemberRsp
{
    /// <summary>
    ///     从HttpContext 创建上下文会员信息
    /// </summary>
    public static ContextMemberInfo Create()
    {
        var ret = App.HttpContext?.Items[nameof(Chars.FLG_CONTEXT_MEMBER_INFO)] as QueryMemberRsp;
        return ret?.Adapt<ContextMemberInfo>();
    }

    /// <summary>
    ///     是否存在于 HttpContext
    /// </summary>
    public static bool HasInContext()
    {
        return App.HttpContext?.Items.ContainsKey(Chars.FLG_CONTEXT_MEMBER_INFO) ?? false;
    }
}