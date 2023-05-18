namespace ShopCore.Domain.Dto.Dependency;

/// <summary>
///     请求：分页查询
/// </summary>
public sealed record PagedQueryReq<T> : QueryReq<T>, IPagedInfo
    where T : DataAbstraction, new()
{
    /// <inheritdoc cref="IPagedInfo.Page" />
    [Range(1, Numbers.QUERY_MAX_PAGE_NO)]
    public int Page { get; init; } = 1;

    /// <inheritdoc cref="IPagedInfo.PageSize" />
    [Range(1, Numbers.QUERY_MAX_PAGE_SIZE)]
    public int PageSize { get; init; } = Numbers.QUERY_DEF_PAGE_SIZE;
}