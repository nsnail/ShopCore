namespace ShopCore.Domain.Enums.Biz;

/// <summary>
///     用户变更类型
/// </summary>
[Export]
public enum MemberChangeTypes
{
    /// <summary>
    ///     登录密码变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.登录密码变更))]
    LoginPassword = 1

   ,

    /// <summary>
    ///     交易密码变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.交易密码变更))]
    PayPassword = 2

   ,

    /// <summary>
    ///     支付宝帐号变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.支付宝帐号变更))]
    AlipayAccount = 3

   ,

    /// <summary>
    ///     支付宝姓名变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.支付宝姓名变更))]
    AlipayName = 4

   ,

    /// <summary>
    ///     手机号变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.手机号变更))]
    MobileNumber = 5

   ,

    /// <summary>
    ///     昵称变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.昵称变更))]
    Nick = 6

   ,

    /// <summary>
    ///     等级变更
    /// </summary>
    [ResourceDescription<Ln>(nameof(Ln.等级变更))]
    Level = 7
}