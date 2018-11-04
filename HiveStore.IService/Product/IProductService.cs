using HiveStore.Entity.Product;
using System.Collections.Generic;

namespace HiveStore.IService.Product
{
    public interface IProductService
    {
        void SaveProduct(ProductEntity productEntity);
        List<ProductEntity> GetAllProducts();
        ProductEntity GetProductById(int productId);
    }
}
