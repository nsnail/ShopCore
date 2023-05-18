using ShopCore.Application.Repositories;
using ShopCore.Application.Services;
using ShopCore.BizServer.Application.Services.Biz.Dependency;
using ShopCore.Domain.Contexts;
using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.DbMaps.Sys;
using ShopCore.Domain.Dto.Biz.Investment;
using ShopCore.Domain.Dto.Biz.Member;
using ShopCore.Domain.Dto.Biz.MemberChange;
using ShopCore.Domain.Dto.Biz.MemberGold;
using ShopCore.Domain.Dto.Biz.MemberInvestment;
using ShopCore.Domain.Dto.Biz.TokenWechat;
using ShopCore.Domain.Dto.Biz.UsedNumber;
using ShopCore.Domain.Dto.Dependency;
using ShopCore.Domain.Dto.Sys.User;
using ShopCore.Domain.Enums.Biz;
using ShopCore.SysComponent.Application.Services.Sys.Dependency;

namespace ShopCore.BizServer.Application.Services.Biz;

/// <inheritdoc cref="IMemberService" />
public sealed class MemberService : RepositoryService<Biz_Member, IMemberService>, IMemberService
{
    private readonly IConfigService           _configService;
    private readonly IInvestmentService       _investService;
    private readonly IMemberChangeService     _memberChangeService;
    private readonly IMemberInvestmentService _memberInvestmentService;
    private readonly ISmsService              _smsService;
    private readonly IUsedNumberService       _usedNumberService;
    private readonly ContextUserInfo          _userInfo;
    private readonly IUserService             _userService;
    private readonly IMemberWalletService     _walletService;
    private readonly ITokenWechatService      _wechatService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MemberService" /> class.
    /// </summary>
    public MemberService(Repository<Biz_Member> rpo, IUserService userService, IConfigService configService, IUsedNumberService usedNumberService
                       , IMemberWalletService   walletService, IInvestmentService investService, IMemberInvestmentService memberInvestmentService
                       , ITokenWechatService    wechatService, ContextUserInfo userInfo, IMemberChangeService memberChangeService
                       , ISmsService            smsService) //
        : base(rpo)
    {
        _userService             = userService;
        _configService           = configService;
        _usedNumberService       = usedNumberService;
        _walletService           = walletService;
        _investService           = investService;
        _memberInvestmentService = memberInvestmentService;
        _wechatService           = wechatService;
        _userInfo                = userInfo;
        _memberChangeService     = memberChangeService;
        _smsService              = smsService;
    }

    /// <summary>
    ///     批量删除会员
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
    ///     检查支付宝账号是否可用
    /// </summary>
    public async Task<bool> CheckAlipayAvailableAsync(CheckAlipayAvailableReq req)
    {
        var inMember = await QueryInternal(new QueryReq<QueryMemberReq> {
                                                                            DynamicFilter = new DynamicFilterInfo {
                                                                                                Field    = nameof(Biz_Member.AlipayAccount)
                                                                                              , Value    = req.AlipayAccount
                                                                                              , Operator = DynamicFilterOperator.Eq
                                                                                            }
                                                                        })
            .AnyAsync();

        var filters = new List<DynamicFilterInfo> {
                                                      new() {
                                                                Logic = DynamicFilterLogic.Or
                                                              , Filters = new List<DynamicFilterInfo> {
                                                                              new() {
                                                                                        Operator = DynamicFilterOperator.Eq
                                                                                      , Field    = nameof(QueryMemberChangeReq.ValueNew)
                                                                                      , Value    = req.AlipayAccount
                                                                                    }
                                                                            , new() {
                                                                                        Operator = DynamicFilterOperator.Eq
                                                                                      , Field    = nameof(QueryMemberChangeReq.ValueOld)
                                                                                      , Value    = req.AlipayAccount
                                                                                    }
                                                                          }
                                                            }
                                                  };
        var inMemberChange = await _memberChangeService.ExistAsync(new QueryReq<QueryMemberChangeReq> {
                                                                       DynamicFilter = new DynamicFilterInfo {
                                                                                           Field    = nameof(QueryMemberChangeReq.Type)
                                                                                         , Logic    = DynamicFilterLogic.And
                                                                                         , Operator = DynamicFilterOperator.Eq
                                                                                         , Value    = MemberChangeTypes.AlipayAccount
                                                                                         , Filters  = filters
                                                                                       }
                                                                   });
        return !inMember && !inMemberChange;
    }

    /// <summary>
    ///     检查手机号是否可用
    /// </summary>
    public async Task<bool> CheckMobileAvailableAsync(CheckMobileAvailableReq req)
    {
        return await _userService.CheckMobileAvailableAsync(req) && !await Rpo.Select.Where(a => a.Mobile == req.Mobile).AnyAsync();
    }

    /// <summary>
    ///     创建会员
    /// </summary>
    public async Task<QueryMemberRsp> CreateAsync(CreateMemberReq req)
    {
        EnableCascadeSave = true;
        var ret = await Rpo.InsertAsync(req);
        EnableCascadeSave = false;
        return ret.Adapt<QueryMemberRsp>();
    }

    /// <summary>
    ///     删除会员
    /// </summary>
    public Task<int> DeleteAsync(DelReq req)
    {
        return Rpo.DeleteAsync(a => a.Id == req.Id);
    }

    /// <summary>
    ///     判断会员是否存在
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public Task<bool> ExistAsync(QueryReq<QueryMemberReq> req)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     获取单个会员
    /// </summary>
    public async Task<QueryMemberRsp> GetAsync(QueryMemberReq req)
    {
        return (await QueryInternal(new QueryReq<QueryMemberReq> //
                                    {
                                        Filter = req
                                    })
            .ToOneAsync()).Adapt<QueryMemberRsp>();
    }

    /// <summary>
    ///     获取单个会员（带更新锁）
    /// </summary>
    public async Task<QueryMemberRsp> GetForUpdateAsync(QueryMemberReq req)
    {
        return (await QueryInternal(new QueryReq<QueryMemberReq> { Filter = req }).ForUpdate().ToOneAsync()).Adapt<QueryMemberRsp>();
    }

    /// <summary>
    ///     初始化登录密码
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">ShopCoreInvalidOperationException</exception>
    /// <exception cref="InvalidOperationException">新密码不能与旧密码相同</exception>
    public async Task InitLoginPwdAsync(InitLoginPwdReq req)
    {
        // 登录密码已经有值了
        if (_userInfo.Member.PwdLogin != Guid.Empty) {
            throw new ShopCoreInvalidOperationException();
        }

        var member = await GetForUpdateAsync(new QueryMemberReq { Id = _userInfo.Member.Id });
        var pwdNew = req.Password.Pwd().Guid();
        if (pwdNew == member.PwdLogin) {
            throw new InvalidOperationException(Ln.新密码不能与旧密码相同);
        }

        _ = await _memberChangeService.CreateAsync(new CreateMemberChangeReq {
                                                                                 MemberId = member.Id
                                                                               , ValueNew = pwdNew.ToString()
                                                                               , ValueOld = member.PwdLogin.ToString()
                                                                               , Type     = MemberChangeTypes.LoginPassword
                                                                             });
        _ = await UpdateAsync((member with { PwdLogin = pwdNew }).Adapt<UpdateMemberReq>());

        // 修改sysUser密码
        var user = await _userService.GetForUpdateAsync(new QueryUserReq { Id = _userInfo.Id });
        await _userService.UpdateSingleAsync((user with { Password = pwdNew }).Adapt<UpdateUserReq>());
    }

    /// <summary>
    ///     会员密码登录
    /// </summary>
    /// <exception cref="NotImplementedException">NotImplementedException</exception>
    public async Task<MemberLoginRsp> LoginByPwdAsync(MemberPwdLoginReq req)
    {
        var ret = await _userService.PwdLoginAsync(req);
        ret.SetToRspHeader();
        return ret.Adapt<MemberLoginRsp>();
    }

    /// <summary>
    ///     会员短信登录
    /// </summary>
    public async Task<MemberLoginRsp> LoginBySmsAsync(MemberSmsLoginReq req)
    {
        var ret = await _userService.SmsLoginAsync(req.Adapt<SmsLoginReq>());
        ret.SetToRspHeader();
        return ret.Adapt<MemberLoginRsp>();
    }

    /// <summary>
    ///     分页查询会员
    /// </summary>
    public async Task<PagedQueryRsp<QueryMemberRsp>> PagedQueryAsync(PagedQueryReq<QueryMemberReq> req)
    {
        var list = await QueryInternal(req).Page(req.Page, req.PageSize).Count(out var total).ToListAsync();

        return new PagedQueryRsp<QueryMemberRsp>(req.Page, req.PageSize, total, list.Adapt<IEnumerable<QueryMemberRsp>>());
    }

    /// <summary>
    ///     查询会员
    /// </summary>
    public async Task<IEnumerable<QueryMemberRsp>> QueryAsync(QueryReq<QueryMemberReq> req)
    {
        var ret = await QueryInternal(req).Take(req.Count).ToListAsync();
        return ret.Adapt<IEnumerable<QueryMemberRsp>>();
    }

    /// <summary>
    ///     查询会员（使用邀请码）
    /// </summary>
    public async Task<QueryMemberByInviteCodeRsp> QueryMemberByInviteCodeAsync(QueryMemberByInviteCodeReq req)
    {
        var ret = await GetByInviteCodeAsync(req.InviteCode);
        return ret.Adapt<QueryMemberByInviteCodeRsp>();
    }

    /// <summary>
    ///     会员注册
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">手机号已被注册</exception>
    /// <exception cref="ShopCoreInvalidOperationException">邀请码不正确</exception>
    public async Task<RegisterMemberRsp> RegisterAsync(RegisterMemberReq req)
    {
        // 判断手机号是否可用
        if (await Rpo.Where(a => a.Mobile == req.VerifySmsCodeReq.DestMobile).AnyAsync()) {
            throw new ShopCoreInvalidOperationException(Ln.手机号已被注册);
        }

        // 获取邀请者信息
        Biz_Member inviter = null;
        if (req.InviterCode != Numbers.SUPER_INVITE_CODE) {
            inviter = await GetByInviteCodeAsync(req.InviterCode);
            if (inviter is null) {
                throw new ShopCoreInvalidOperationException(Ln.邀请码不正确);
            }
        }

        // 获取配置信息
        var config = await _configService.GetLatestConfigAsync();

        // 创建系统用户
        var sysUser = await _userService.RegisterAsync(req.Adapt<RegisterReq>() //
                                                           with {
                                                                    DeptId = config.UserRegisterDeptId
                                                                  , PositionIds = new[] { config.UserRegisterPosId }
                                                                  , RoleIds = new[] { config.UserRegisterRoleId }
                                                                  , Enabled = !config.UserRegisterConfirm
                                                                });

        // 创建会员
        var member = await CreateAsync(await BuildCreateMemberReqAsync(sysUser, inviter));

        // 赠送金币
        await _walletService.ExchangeGoldAsync(new ExchangeGoldReq {
                                                                       MemberId = member.Id
                                                                     , Amount   = Numbers.REGISTER_GIFT_GOLD + Numbers.REGISTER_INVEST_GOLD
                                                                     , Data     = Ln.注册送金币
                                                                     , Type     = GoldTypes.RegisterGift
                                                                   });

        // 投资金币
        await FirstInvestAsync(member);

        // 赠送银币
        await _walletService.ExchangeSilverAsync(new ExchangeSilverReq {
                                                                           Amount   = Numbers.REGISTER_GIFT_SILVER
                                                                         , Data     = Ln.注册送银币
                                                                         , Type     = SilverTypes.AdminGift
                                                                         , MemberId = member.Id
                                                                       });

        // 绑定微信
        if (!req.WechatId.NullOrEmpty()) {
            var wechat = await _wechatService.GetByOpenIdAsync(new QueryTokenWechatReq { OpenId = req.WechatId });
            if (wechat is not null) {
                wechat.MemberId = member.Id;
                member.Nick     = wechat.NickName;
                member.Avatar   = wechat.HeadImgUrl;
                _               = await _wechatService.UpdateAsync(wechat.Adapt<UpdateTokenWechatReq>());
                _               = await UpdateAsync(member.Adapt<UpdateMemberReq>());
            }
        }

        return member.Adapt<RegisterMemberRsp>();
    }

    /// <summary>
    ///     设置支付宝
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">此支付宝已被其他人使用</exception>
    public async Task SetAlipayAsync(SetAlipayReq req)
    {
        var member = await GetForUpdateAsync(new QueryMemberReq { Id = _userInfo.Member.Id });
        if (member.AlipayAccount == req.AlipayAccount && member.AlipayName == req.AlipayName) {
            return;
        }

        if (req.AlipayAccount != member.AlipayAccount) {
            if (!await CheckAlipayAvailableAsync(req.Adapt<CheckAlipayAvailableReq>())) {
                throw new ShopCoreInvalidOperationException(Ln.此支付宝已被其他人使用);
            }

            _ = await _memberChangeService.CreateAsync(new CreateMemberChangeReq {
                                                                                     Type     = MemberChangeTypes.AlipayAccount
                                                                                   , MemberId = member.Id
                                                                                   , ValueNew = req.AlipayAccount
                                                                                   , ValueOld = member.AlipayAccount
                                                                                 });
        }

        if (req.AlipayName != member.AlipayName) {
            _ = await _memberChangeService.CreateAsync(new CreateMemberChangeReq {
                                                                                     Type     = MemberChangeTypes.AlipayName
                                                                                   , MemberId = member.Id
                                                                                   , ValueNew = req.AlipayName
                                                                                   , ValueOld = member.AlipayName
                                                                                 });
        }

        _ = await UpdateAsync((member with { AlipayAccount = req.AlipayAccount, AlipayName = req.AlipayName }).Adapt<UpdateMemberReq>());
    }

    /// <summary>
    ///     设置昵称
    /// </summary>
    public async Task SetNickAsync(SetNickReq req)
    {
        var member = await GetForUpdateAsync(new QueryMemberReq { Id            = _userInfo.Member.Id });
        var user   = await _userService.GetForUpdateAsync(new QueryUserReq { Id = _userInfo.Id });
        _ = await _memberChangeService.CreateAsync(new CreateMemberChangeReq {
                                                                                 MemberId = member.Id
                                                                               , ValueNew = req.Nick
                                                                               , ValueOld = member.Nick
                                                                               , Type     = MemberChangeTypes.Nick
                                                                             });
        _ = await UpdateAsync((member with { Nick = req.Nick }).Adapt<UpdateMemberReq>());
        await _userService.UpdateSingleAsync((user with { UserName = req.Nick }).Adapt<UpdateUserReq>());
    }

    /// <summary>
    ///     设置交易密码
    /// </summary>
    /// <exception cref="ShopCoreInvalidOperationException">短信验证码不正确</exception>
    /// <exception cref="InvalidOperationException">新密码不能与旧密码相同</exception>
    public async Task SetPayPwdAsync(SetPayPwdReq req)
    {
        if (req.DestMobile != _userInfo.Mobile || !await _smsService.VerifySmsCodeAsync(req)) {
            throw new ShopCoreInvalidOperationException(Ln.短信验证码不正确);
        }

        var member = await GetForUpdateAsync(new QueryMemberReq { Id = _userInfo.Member.Id });
        var pwdNew = req.PayPwd.Pwd().Guid();
        if (pwdNew == member.PwdPay) {
            throw new InvalidOperationException(Ln.新密码不能与旧密码相同);
        }

        _ = await _memberChangeService.CreateAsync(new CreateMemberChangeReq {
                                                                                 MemberId = member.Id
                                                                               , ValueNew = pwdNew.ToString()
                                                                               , ValueOld = member.PwdPay.ToString()
                                                                               , Type     = MemberChangeTypes.PayPassword
                                                                             });
        _ = await UpdateAsync((member with { PwdPay = pwdNew }).Adapt<UpdateMemberReq>());
    }

    /// <summary>
    ///     更新会员
    /// </summary>
    public async Task<QueryMemberRsp> UpdateAsync(UpdateMemberReq req)
    {
        var ret = await Rpo.UpdateDiy.SetSource(req).ExecuteUpdatedAsync();
        return ret.FirstOrDefault()?.Adapt<QueryMemberRsp>();
    }

    private async Task<CreateMemberReq> BuildCreateMemberReqAsync(Sys_User sysUser, Biz_Member inviter)
    {
        var createMemberReq = sysUser.Adapt<CreateMemberReq>();
        var level           = inviter?.Level + 1 ?? MemberLevels.Diamond;
        if (level > MemberLevels.Silver) {
            level = MemberLevels.Silver;
        }

        var inviteCode = (int)(await _usedNumberService.CreateAsync(new CreateUsedNumberReq { Min = 10000000, Max = 100000000 })).Number;
        var @fixed = new Biz_MemberFixed //
                     {
                         RegisterSource = App.HttpContext.Request.GetRefererUrlAddress()
                     };
        return createMemberReq with {
                                        InviteCode = inviteCode
                                      , Nick = sysUser.UserName
                                      , Wallet = new Biz_MemberWallet { Id = createMemberReq.Id }
                                      , Fixed = @fixed
                                      , UserId = sysUser.Id
                                      , InviterId = inviter?.Id
                                      , Level = level
                                    };
    }

    private async Task FirstInvestAsync(QueryMemberRsp member)
    {
        var invest = await _investService.GetAsync(new QueryInvestmentReq { Id = Numbers.NEW_USER_BUY_INVEST_ID });
        if (invest?.Status != InvestStatues.Online) {
            throw new ShopCoreUnexpectedException(Ln.投资产品已下线);
        }

        // 会员投资
        var goldInterest = (long)Math.Ceiling(Numbers.REGISTER_INVEST_GOLD * invest.Rate / invest.Days * invest.Days);
        _ = await _memberInvestmentService.CreateAsync(new CreateMemberInvestmentReq {
                                                                                         MemberId     = member.Id
                                                                                       , GoldCapital  = Numbers.REGISTER_INVEST_GOLD
                                                                                       , GoldInterest = goldInterest
                                                                                       , InvestId     = invest.Id
                                                                                       , Status       = MemberInvestStatues.Running
                                                                                     });

        // 变更钱包
        await _walletService.ExchangeGoldAsync(new ExchangeGoldReq {
                                                                       MemberId = member.Id
                                                                     , Type     = GoldTypes.Save2Coffer
                                                                     , Amount   = -Numbers.REGISTER_INVEST_GOLD
                                                                     , Data     = $"{Ln.注册送金币} - {Ln.存入小金库}"
                                                                   });
    }

    private Task<Biz_Member> GetByInviteCodeAsync(int inviteCode)
    {
        return QueryInternal(new QueryReq<QueryMemberReq> //
                             {
                                 DynamicFilter = new DynamicFilterInfo {
                                                                           Field    = nameof(Biz_Member.InviteCode)
                                                                         , Operator = DynamicFilterOperator.Eq
                                                                         , Value    = inviteCode
                                                                       }
                             })
            .ToOneAsync();
    }

    private ISelect<Biz_Member> QueryInternal(QueryReq<QueryMemberReq> req)
    {
        return Rpo.Select.WhereDynamicFilter(req.DynamicFilter)
                  .WhereDynamic(req.Filter)
                  .OrderByPropertyNameIf(req.Prop?.Length > 0, req.Prop, req.Order == Orders.Ascending)
                  .OrderByDescending(a => a.Id);
    }
}