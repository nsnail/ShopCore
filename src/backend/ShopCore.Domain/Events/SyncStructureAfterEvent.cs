namespace ShopCore.Domain.Events;

/// <summary>
///     同步数据库结构之后事件
/// </summary>
public sealed record SyncStructureAfterEvent : SyncStructureBeforeEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SyncStructureAfterEvent" /> class.
    /// </summary>
    public SyncStructureAfterEvent(SyncStructureBeforeEventArgs e) //
        : base(e)
    {
        EventId = nameof(SyncStructureAfterEvent);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "{0}: {1} {2} {3} {4}: {5}", Id, Ln.数据库, Ln.结构, Ln.同步, Ln.完成
                           , string.Join(',', EntityTypes.Select(x => x.Name)));
    }
}