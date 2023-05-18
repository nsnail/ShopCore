namespace ShopCore.Infrastructure.Exceptions;

/// <summary>
///     Line异常基类
/// </summary>
#pragma warning disable RCS1194
public abstract class ShopCoreException : Exception
    #pragma warning restore RCS1194
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShopCoreException" /> class.
    /// </summary>
    protected ShopCoreException(ErrorCodes code, string message = null, Exception innerException = null) //
        : base(message, innerException)
    {
        Code = code;
    }

    /// <summary>
    ///     错误码
    /// </summary>
    public ErrorCodes Code { get; }
}