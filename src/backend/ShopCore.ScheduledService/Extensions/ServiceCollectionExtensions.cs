using Furion.Schedule;
using ShopCore.ScheduledService.Jobs;

namespace ShopCore.ScheduledService.Extensions;

/// <summary>
///     ServiceCollection 扩展方法
/// </summary>
[SuppressSniffer]
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     注册定时任务
    /// </summary>
    public static IServiceCollection AddSchedules(this IServiceCollection me)
    {
        _ = me.AddSchedule(builder => builder.AddJob<ExampleJob>(Triggers.Minutely()))

            //
            ;
        return me;
    }
}