using HiveStore.Entity.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.IRepository.Product
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity productEntity);
        List<ProductEntity> GetAllProducts();
        ProductEntity GetProductById(int productId);
        string SaveChanges();
    }
}
