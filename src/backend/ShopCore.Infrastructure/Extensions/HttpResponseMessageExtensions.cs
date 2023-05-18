namespace ShopCore.Infrastructure.Extensions;

/// <summary>
///     HttpResponseMessage 扩展方法
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    ///     记录日志
    /// </summary>
    public static async Task LogAsync<T>(this HttpResponseMessage me, ILogger<T> logger
                                       , Func<string, string>     bodyPreHandle = null)
    {
        logger.Info(await me.BuildJsonAsync(bodyPreHandle));
    }

    /// <summary>
    ///     记录异常日志
    /// </summary>
    public static async Task LogExceptionAsync<T>(this HttpResponseMessage me, string errors, ILogger<T> logger
                                                , Func<string, string>     bodyHandle = null)
    {
        logger.Warn($"{errors}: {await me.BuildJsonAsync(bodyHandle)}");
    }

    /// <summary>
    ///     将Http请求的Uri、Header、Body打包成Json字符串
    /// </summary>
    private static async Task<string> BuildJsonAsync( //
        this HttpResponseMessage me, Func<string, string> bodyHandle = null)
    {
        var body = me?.Content is null ? null : await me.Content!.ReadAsStringAsync();
        return new { Header = me?.ToString(), Body = bodyHandle is null ? body : bodyHandle(body) }.ToJson();
    }
}