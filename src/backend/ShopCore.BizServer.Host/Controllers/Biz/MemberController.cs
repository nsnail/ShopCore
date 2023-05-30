using ShopCore.BizServer.Application.Modules.Biz;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Host.Attributes;
using ShopCore.Host.Controllers;

namespace ShopCore.BizServer.Host.Controllers.Biz;

/// <summary>
///     会员服务
/// </summary>
[ApiDescriptionSettings(nameof(Biz), Module = nameof(Biz))]
public sealed class MemberController : ControllerBase<IMemberService>, IMemberModule
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberController" /> class.
    /// </summary>
    public MemberController(IMemberService service) //
        : base(service) { }

    /// <summary>
    ///     批量删除会员
    /// </summary>
    [Transaction]
    public Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        return Service.BulkDeleteAsync(req);
    }

    /// <summary>
    ///     创建会员
    /// </summary>
    [Transaction]
    public Task<QueryMemberRsp> CreateAsync(CreateMemberReq req)
    {
        return Service.CreateAsync(req);
    }

    /// <summary>
    ///     删除会员
    /// </summary>
    [Transaction]
    public Task<int> DeleteAsync(DelReq req)
    {
        return Service.DeleteAsync(req);
    }

    /// <summary>
    ///     会员是否存在
    /// </summary>
    [NonAction]
    public Task<bool> ExistAsync(QueryReq<QueryMemberReq> req)
    {
        return Service.ExistAsync(req);
    }

    /// <summary>
    ///     获取单个会员
    /// </summary>
    [NonAction]
    public Task<QueryMemberRsp> GetAsync(QueryMemberReq req)
    {
        return Service.GetAsync(req);
    }

    /// <summary>
    ///     分页查询会员
    /// </summary>
    public Task<PagedQueryRsp<QueryMemberRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberReq> req)
    {
        return Service.PagedQueryAsync(req);
    }

    /// <summary>
    ///     查询会员
    /// </summary>
    public Task<IEnumerable<QueryMemberRsp>> QueryAsync(QueryReq<QueryMemberReq> req)
    {
        return Service.QueryAsync(req);
    }

    /// <summary>
    ///     会员注册
    /// </summary>
    [AllowAnonymous]
    [Transaction]
    public Task<QueryMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        return Service.RegisterAsync(req);
    }

    /// <summary>
    ///     更新会员
    /// </summary>
    [Transaction]
    public Task<QueryMemberRsp> UpdateAsync(UpdateMemberReq req)
    {
        return Service.UpdateAsync(req);
    }
}