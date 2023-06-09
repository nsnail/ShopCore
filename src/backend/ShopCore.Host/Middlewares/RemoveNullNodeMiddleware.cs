using ShopCore.Host.Attributes;
using ShopCore.Host.Extensions;

namespace ShopCore.Host.Middlewares;

/// <summary>
///     删除 response json body 中value 为null的节点
/// </summary>
public sealed class RemoveNullNodeMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RemoveNullNodeMiddleware" /> class.
    /// </summary>
    public RemoveNullNodeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    ///     InvokeAsync
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.GetMetadata<RemoveNullNodeAttribute>() == null) {
            return;
        }

        await context.RemoveJsonNodeWithNullValueAsync();
    }
}