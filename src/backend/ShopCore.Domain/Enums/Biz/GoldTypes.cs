using ShopCore.Domain.Attributes;

namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     金币类型
/// </summary>
[Export]
public enum GoldTypes
{
    /// <summary>
    ///     银币兑金币
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.银币兑金币))]
    Silver2Gold = 1

   ,

    /// <summary>
    ///     兑换现金
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.兑换现金))]
    Gold2Rmb = 2

   ,

    /// <summary>
    ///     管理员赠送
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.管理员赠送))]
    AdminGift = 3

   ,

    /// <summary>
    ///     兑现金退款
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.兑现金退款))]
    Gold2RmbRollback = 4

   ,

    /// <summary>
    ///     存入小金库
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.存入小金库))]
    Save2Coffer = 5

   ,

    /// <summary>
    ///     淘宝返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.淘宝返利))]
    TaobaoRebate = 6

   ,

    /// <summary>
    ///     团队订单收入
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.团队订单收入))]
    TeamTradeIncome = 7

   ,

    /// <summary>
    ///     京东返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.京东返利))]
    JdRebate = 8

   ,

    /// <summary>
    ///     拼多多返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.拼多多返利))]
    PddRebate = 9

   ,

    /// <summary>
    ///     苏宁返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.苏宁返利))]
    SnRebate = 10

   ,

    /// <summary>
    ///     唯品会返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.唯品会返利))]
    WphRebate = 11

   ,

    /// <summary>
    ///     免单补贴
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.免单补贴))]
    FreeOrderSubsidy = 12

   ,

    /// <summary>
    ///     订单补贴卡
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.订单补贴卡))]
    SubsidyCard = 13

   ,

    /// <summary>
    ///     小金库本金返还
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.小金库本金返还))]
    PopCoffer = 14

   ,

    /// <summary>
    ///     小金库利息
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.小金库利息))]
    CofferInterest = 15

   ,

    /// <summary>
    ///     粉丝实名奖励
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.粉丝实名奖励))]
    FansRealNameReward = 16

   ,

    /// <summary>
    ///     粉丝首单奖励
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.粉丝首单奖励))]
    FansFirstTradeReward = 17

   ,

    /// <summary>
    ///     粉丝首提奖励
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.粉丝首提奖励))]
    FansFirstWithdrawReward = 18

   ,

    /// <summary>
    ///     悬赏注册处罚
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.悬赏注册处罚))]
    ValueForInviteForfeit = 19

   ,

    /// <summary>
    ///     注册礼金
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.注册礼金))]
    RegisterGift = 20

   ,

    /// <summary>
    ///     购买年卡会员
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.购买年卡会员))]
    BuyVip = 21

   ,

    /// <summary>
    ///     美团返利
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.美团返利))]
    MeituanRebate = 22

   ,

    /// <summary>
    ///     粉丝授权奖励
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.粉丝授权奖励))]
    FansAuthorizeReward = 23

   ,

    /// <summary>
    ///     粉丝购年卡奖励
    /// </summary>
    [IsIncome]
    [ResourceDescription<Ln>(nameof(Ln.粉丝购年卡奖励))]
    FansBuyVipReward = 24

   ,

    /// <summary>
    ///     淘宝维权订单
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.淘宝维权订单))]
    TaobaoRefundTrade = 25

   ,

    /// <summary>
    ///     虚假交易处罚
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.虚假交易处罚))]
    WashSaleForfeit = 26

   ,

    /// <summary>
    ///     店铺淘客处罚
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.店铺淘客处罚))]
    ShopTaokeForfeit = 27

   ,

    /// <summary>
    ///     京东违规或退款
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.京东违规或退款))]
    JdPerverse = 28

   ,

    /// <summary>
    ///     重复打款退回
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.重复打款退回))]
    DuplicatePayRollback = 29
}