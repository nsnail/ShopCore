namespace ShopCore.Infrastructure;

/// <summary>
///     全局静态类
/// </summary>
public static class Global
{
    /// <summary>
    ///     产品版本
    /// </summary>
    public static readonly string ProductVersion
        = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()!.Location).ProductVersion;

    /// <summary>
    ///     系统内部密钥
    /// </summary>
    public static string SecretKey => "{6C4922D3-499A-46db-BFC4-0B51A9C4395F}";

    /// <summary>
    ///     Json序列化选项
    /// </summary>
    public static JsonSerializerOptions JsonSerializerOptions { get; set; }
}