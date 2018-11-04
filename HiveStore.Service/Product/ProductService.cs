using HiveStore.Entity.Product;
using HiveStore.IRepository.Product;
using HiveStore.IService.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Service.Product
{
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public void SaveProduct(ProductEntity productEntity)
        {
            try
            {
                if (productEntity.Id > 0)
                {
                    ProductEntity productEntity_saved = ProductRepository.GetProductById(productEntity.Id);
                    productEntity_saved.ProductName = productEntity.ProductName;
                    productEntity_saved.UnitPrice = productEntity.UnitPrice;
                    productEntity_saved.ModifiedBy = System.Environment.UserName;
                    productEntity_saved.ModifiedDate = DateTime.Now;
                }
                else
                {
                    productEntity.CreatedBy = System.Environment.UserName;
                    productEntity.ModifiedBy = System.Environment.UserName;
                    productEntity.CreatedDate = DateTime.Now;
                    productEntity.ModifiedDate = DateTime.Now;
                    ProductRepository.AddProduct(productEntity);
                }
                ProductRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<ProductEntity> GetAllProducts()
        {
            return ProductRepository.GetAllProducts();
        }

        public ProductEntity GetProductById(int productId)
        {
            return ProductRepository.GetProductById(productId);
        }
    }
}
