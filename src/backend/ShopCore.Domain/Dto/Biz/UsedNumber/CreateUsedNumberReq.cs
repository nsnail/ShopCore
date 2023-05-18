using ShopCore.Domain.DbMaps.Biz;

namespace ShopCore.Domain.Dto.Biz.UsedNumber;

/// <summary>
///     请求：创建取号
/// </summary>
public record CreateUsedNumberReq : Biz_UsedNumber
{
    /// <summary>
    ///     最大值（不包含）
    /// </summary>
    public int Max { get; init; }

    /// <summary>
    ///     最小值
    /// </summary>
    public int Min { get; init; }
}