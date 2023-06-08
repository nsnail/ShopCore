using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Cache;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Cache.Biz.Implements;

/// <inheritdoc cref="IMemberCache" />
public sealed class MemberCache : DistributedCache<IMemberService>, IScoped, IMemberCache
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberCache" /> class.
    /// </summary>
    public MemberCache(IDistributedCache cache, IMemberService service) //
        : base(cache, service) { }

    /// <inheritdoc />
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<QueryMemberRsp> CreateAsync(CreateMemberReq req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<int> DeleteAsync(DelReq req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<bool> ExistAsync(QueryReq<QueryMemberReq> req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<QueryMemberRsp> GetAsync(QueryMemberReq req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<QueryMemberRsp> MemberInfoAsync()
    {
        return GetOrCreateAsync( //
            GetCacheKey(Service.UserToken.Id.ToString(CultureInfo.InvariantCulture)), Service.MemberInfoAsync
,                                                                                     TimeSpan.FromMinutes(1));
    }

    /// <inheritdoc />
    public Task<PagedQueryRsp<QueryMemberRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberReq> req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IEnumerable<QueryMemberRsp>> QueryAsync(QueryReq<QueryMemberReq> req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<QueryMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<QueryMemberRsp> UpdateAsync(UpdateMemberReq req)
    {
        throw new NotImplementedException();
    }
}