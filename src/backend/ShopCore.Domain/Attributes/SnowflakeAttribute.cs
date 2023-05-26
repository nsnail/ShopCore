// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ShopCore.Domain.Attributes;

/// <summary>
///     标记一个字段启用雪花编号生成
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class SnowflakeAttribute : Attribute
{
    //
}