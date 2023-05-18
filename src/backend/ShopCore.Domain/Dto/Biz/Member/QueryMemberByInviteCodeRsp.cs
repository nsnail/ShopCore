using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.Member;

/// <summary>
///     响应：查询会员（使用邀请码）
/// </summary>
public record QueryMemberByInviteCodeRsp : Biz_Member
{
    /// <summary>
    ///     手机号
    /// </summary>
    public string MaskMobile => Mobile.MaskMobile();

    /// <summary>
    ///     头像地址
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Avatar { get; set; }

    /// <summary>
    ///     唯一编码
    /// </summary>
    [JsonIgnore]
    public override long Id { get; init; }

    /// <summary>
    ///     昵称
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Nick { get; set; }
}