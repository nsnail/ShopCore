using Furion.Schedule;
using ShopCore.Host.BackgroundRunning;

namespace ShopCore.ScheduledService.Jobs;

/// <summary>
///     示例Job
/// </summary>
public sealed class ExampleJob : WorkBase<ExampleJob>, IJob
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ExampleJob" /> class.
    /// </summary>
    public ExampleJob() { }

    /// <summary>
    ///     具体处理逻辑
    /// </summary>
    /// <param name="context">作业执行前上下文</param>
    /// <param name="stoppingToken">取消任务 Token</param>
    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        await WorkflowAsync(stoppingToken);
    }

    /// <summary>
    ///     通用工作流
    /// </summary>
    protected override ValueTask WorkflowAsync(CancellationToken cancelToken)
    {
        return ValueTask.CompletedTask;
    }
}