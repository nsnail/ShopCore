using ShopCore.Domain.Contexts;

namespace ShopCore.Application.Services;

/// <inheritdoc />
public abstract class ServiceBase<TLogger> : ServiceBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServiceBase{TLogger}" /> class.
    /// </summary>
    protected ServiceBase() //
    {
        Logger = App.GetService<ILogger<TLogger>>();
    }

    /// <summary>
    ///     日志记录器
    /// </summary>
    protected ILogger<TLogger> Logger { get; }
}

/// <summary>
///     服务基类
/// </summary>
public abstract class ServiceBase : IScoped, IService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServiceBase" /> class.
    /// </summary>
    protected ServiceBase()
    {
        UserToken = App.GetService<ContextUserToken>();
        ServiceId = Guid.NewGuid();
    }

    /// <summary>
    ///     服务编号
    /// </summary>
    public Guid ServiceId { get; set; }

    /// <summary>
    ///     上下文用户
    /// </summary>
    public ContextUserToken UserToken { get; set; }
}