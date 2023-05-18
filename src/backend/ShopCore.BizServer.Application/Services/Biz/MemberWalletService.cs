using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Attributes;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Biz.MemberSilver;
using ShopCore.Domain.Dto.Biz.MemberWallet;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberWalletService" />
public sealed class MemberWalletService : RepositoryService<Biz_MemberWallet, IMemberWalletService>
                                        , IMemberWalletService
{
    private readonly IMemberGoldService   _memberGoldService;
    private readonly IMemberSilverService _memberSilverService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberWalletService" /> class.
    /// </summary>
    public MemberWalletService(Repository<Biz_MemberWallet> rpo, IMemberGoldService memberGoldService
                             , IMemberSilverService         memberSilverService) //
        : base(rpo)
    {
        _memberGoldService   = memberGoldService;
        _memberSilverService = memberSilverService;
    }

    /// <summary>
    ///     批量删除会员钱包
    /// </summary>
    public async Task<int> BulkDeleteAsync(BulkReq<DelReq> req)
    {
        var sum = 0;
        foreach (var item in req.Items) {
            sum += await DeleteAsync(item);
        }

        return sum;
    }

    /// <summary>
    ///     创建会员钱包
    /// </summary>
    public async Task<QueryMemberWalletRsp> CreateAsync(CreateMemberWalletReq req)
    {
        var ret = await Rpo.InsertAsync(req);
        return ret.Adapt<QueryMemberWalletRsp>();
    }

    /// <summary>
    ///     删除会员钱包
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     交易金币
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">交易后用户金币小于0</exception>
    /// <exception cref="ShopCoreInvalidInputException">ShopCoreInvalidInputException</exception>
    public async Task ExchangeGoldAsync(ExchangeGoldReq req)
    {
        var reqValidate = req.TryValidate();
        if (!reqValidate.IsValid) {
            throw new ShopCoreInvalidInputException(string.Join( //
                                                   Environment.NewLine
                                                 , reqValidate.ValidationResults.Select(x => x.ErrorMessage)));
        }

        var member = await App.GetService<IMemberService>().GetAsync(new QueryMemberReq { Id = req.MemberId });
        Console.WriteLine(member);

        var memberWallet = await GetForUpdateAsync(new QueryMemberWalletReq { Id = req.MemberId });

        // 金币交易日志
        var exchangeLog = new CreateMemberGoldReq {
                                                      Amount        = req.Amount
                                                    , MemberId      = req.MemberId
                                                    , BalanceAfter  = memberWallet.Gold + req.Amount
                                                    , BalanceBefore = memberWallet.Gold
                                                    , Data          = req.Data
                                                    , Type          = req.Type
                                                  };
        _ = await _memberGoldService.CreateAsync(exchangeLog);

        // 更新钱包
        memberWallet.Gold += req.Amount;

        // 如果金币<0，报错
        if (memberWallet.Gold < 0) {
            throw new ShopCoreInvalidOperationException(Ln.交易后用户金币小于0);
        }

        // 累计赚金币更新
        if (typeof(GoldTypes).GetField(req.Type.ToString())!.GetCustomAttribute(typeof(IsIncomeAttribute), false) is
            IsIncomeAttribute) {
            memberWallet.GoldOfSum += req.Amount;
            if (new[] {
                          GoldTypes.TeamTradeIncome, GoldTypes.TaobaoRebate, GoldTypes.JdRebate, GoldTypes.PddRebate
                        , GoldTypes.SnRebate, GoldTypes.WphRebate
                      }.Contains(req.Type)) {
                memberWallet.GoldOfOrder += req.Amount;
            }
        }

        // 钱包后续处理
        req.WalletProc?.Invoke(memberWallet);

        _ = await UpdateAsync(memberWallet.Adapt<UpdateMemberWalletReq>());
    }

    /// <summary>
    ///     交易银币
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">交易后用户银币小于0</exception>
    /// <exception cref="ShopCoreInvalidInputException">ShopCoreInvalidInputException</exception>
    public async Task ExchangeSilverAsync(ExchangeSilverReq req)
    {
        var reqValidate = req.TryValidate();
        if (!reqValidate.IsValid) {
            throw new ShopCoreInvalidInputException(string.Join( //
                                                   Environment.NewLine
                                                 , reqValidate.ValidationResults.Select(x => x.ErrorMessage)));
        }

        var member = await App.GetService<IMemberService>().GetAsync(new QueryMemberReq { Id = req.MemberId });
        Console.WriteLine(member);

        var memberWallet = await GetForUpdateAsync(new QueryMemberWalletReq { Id = req.MemberId });

        // 银币交易日志
        var exchangeLog = new CreateMemberSilverReq {
                                                        Amount        = req.Amount
                                                      , MemberId      = req.MemberId
                                                      , BalanceAfter  = memberWallet.Silver + req.Amount
                                                      , BalanceBefore = memberWallet.Silver
                                                      , Data          = req.Data
                                                      , Type          = req.Type
                                                    };
        _ = await _memberSilverService.CreateAsync(exchangeLog);

        // 更新钱包
        memberWallet.Silver += req.Amount;

        // 如果银币<0，报错
        if (memberWallet.Silver < 0) {
            throw new ShopCoreInvalidOperationException(Ln.交易后用户银币小于0);
        }

        // 钱包后续处理
        req.WalletProc?.Invoke(memberWallet);

        _ = await UpdateAsync(memberWallet.Adapt<UpdateMemberWalletReq>());
    }

    /// <summary>
    ///     判断会员钱包是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberWalletReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员钱包
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<QueryMemberWalletRsp> GetAsync(QueryMemberWalletReq req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个钱包（带更新锁）
    /// </summary>
    public async Task<QueryMemberWalletRsp> GetForUpdateAsync(QueryMemberWalletReq req)
    {
        return (await QueryInternal(new QueryReq<QueryMemberWalletReq> { Filter = req }).ForUpdate().ToOneAsync())
            .Adapt<QueryMemberWalletRsp>();
    }

    /// <summary>
    ///     分页查询会员钱包
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberWalletRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberWalletReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberWalletRsp>(req.Page, req.PageSize, total
                                                     , list.Adapt<IEnumerable<QueryMemberWalletRsp>>());
    }

    /// <summary>
    ///     查询会员钱包
    /// </summary>
    public async Task<IEnumerable<QueryMemberWalletRsp>> QueryAsync(QueryReq<QueryMemberWalletReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberWalletRsp>>();
    }

    /// <summary>
    ///     更新会员钱包
    /// </summary>
    public async Task<QueryMemberWalletRsp> UpdateAsync(UpdateMemberWalletReq req)
    {
        var ret = await Rpo.UpdateAsync(req);
        return ret.Adapt<QueryMemberWalletRsp>();
    }

    private ISelect<Biz_MemberWallet> QueryInternal(QueryReq<QueryMemberWalletReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}