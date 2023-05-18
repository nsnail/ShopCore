using ShopCore.Domain.DbMaps.Biz;
using ShopCore.Domain.Enums.Biz;

namespace ShopCore.Domain.Dto.Biz.MemberGold;

/// <summary>
///     请求：交易银币
/// </summary>
public record ExchangeSilverReq : DataAbstraction
{
    /// <summary>
    ///     交易金额
    /// </summary>
    [Range(-int.MaxValue, int.MaxValue)]
    public long Amount { get; init; }

    /// <summary>
    ///     附加数据
    /// </summary>
    public string Data { get; init; }

    /// <summary>
    ///     会员编号
    /// </summary>
    public long MemberId { get; init; }

    /// <summary>
    ///     银币类型
    /// </summary>
    [EnumDataType(typeof(SilverTypes))]
    public SilverTypes Type { get; init; }

    /// <summary>
    ///     钱包处理函数
    /// </summary>
    public Action<Biz_MemberWallet> WalletProc { get; init; }
}