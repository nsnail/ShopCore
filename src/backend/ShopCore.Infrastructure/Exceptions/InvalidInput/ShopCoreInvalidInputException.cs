namespace ShopCore.Infrastructure.Exceptions.InvalidInput;

/// <summary>
///     无效输入异常
/// </summary>
/// <remarks>
///     参数格式错误、内容校验错误等
/// </remarks>
#pragma warning disable RCS1194
public sealed class ShopCoreInvalidInputException : ShopCoreException
    #pragma warning restore RCS1194
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShopCoreInvalidInputException" /> class.
    /// </summary>
    public ShopCoreInvalidInputException(string message = null, Exception innerException = null) //
        : base(ErrorCodes.InvalidInput, message, innerException) { }
}