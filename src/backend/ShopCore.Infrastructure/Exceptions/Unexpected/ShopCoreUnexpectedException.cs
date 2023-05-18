namespace ShopCore.Infrastructure.Exceptions.Unexpected;

/// <summary>
///     非预期结果异常
/// </summary>
/// <remarks>
///     运行结果是非预期的，例如事务失败回滚
/// </remarks>
#pragma warning disable RCS1194, DesignedForInheritance
public class ShopCoreUnexpectedException : ShopCoreException
    #pragma warning restore DesignedForInheritance, RCS1194
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShopCoreUnexpectedException" /> class.
    /// </summary>
    public ShopCoreUnexpectedException(string message = null, Exception innerException = null) //
        : base(ErrorCodes.Unexpected, message, innerException) { }
}