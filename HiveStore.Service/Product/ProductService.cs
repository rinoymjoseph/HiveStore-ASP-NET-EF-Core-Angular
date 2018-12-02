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
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void SaveProduct(ProductEntity productEntity)
        {
            try
            {
                if (productEntity.Id > 0)
                {
                    ProductEntity productEntity_saved = _productRepository.GetProductById(productEntity.Id);
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
                    _productRepository.AddProduct(productEntity);
                }
                _productRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<ProductEntity> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public ProductEntity GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
    }
}
