using ShopCore.Application.Modules;
using ShopCore.Domain.Dto.Biz.ProductCategory;
using ShopCore.Domain.Dto.Dependency;

namespace ShopCore.BizServer.Application.Modules.Biz;

/// <summary>
///     商品分类模块
/// </summary>
public interface IProductCategoryModule : ICrudModule<CreateProductCategoryReq, QueryProductCategoryRsp // 创建类型
  , QueryProductCategoryReq, QueryProductCategoryRsp                                                    // 查询类型
  , UpdateProductCategoryReq, QueryProductCategoryRsp                                                   // 修改类型
  , DelReq                                                                                              // 删除类型
> { }