using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.Product;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     商品模块
/// </summary>
public interface IProductModule : ICrudModule<CreateProductReq, QueryProductRsp // 创建类型
  , QueryProductReq, QueryProductRsp                                            // 查询类型
  , UpdateProductReq, QueryProductRsp                                           // 修改类型
  , DelReq                                                                      // 删除类型
> { }