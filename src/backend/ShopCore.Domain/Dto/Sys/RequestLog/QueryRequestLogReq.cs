using ShopCore.Domain.DbMaps.Sys;

namespace ShopCore.Domain.Dto.Sys.RequestLog;

/// <summary>
///     请求：查询请求日志
/// </summary>
public sealed record QueryRequestLogReq : Sys_RequestLog;