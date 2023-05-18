namespace ShopCore.Infrastructure.Exceptions.InvalidOperation;

/// <summary>
///     无效操作异常
/// </summary>
/// <remarks>
///     非正常的业务流程或逻辑
/// </remarks>
#pragma warning disable RCS1194, DesignedForInheritance
public class ShopCoreInvalidOperationException : ShopCoreException
    #pragma warning restore DesignedForInheritance, RCS1194
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ShopCoreInvalidOperationException" /> class.
    /// </summary>
    public ShopCoreInvalidOperationException(string message = null, Exception innerException = null) //
        : base(ErrorCodes.InvalidOperation, message, innerException) { }
}