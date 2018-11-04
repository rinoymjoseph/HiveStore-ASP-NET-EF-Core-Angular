using HiveStore.DataAccess;
using HiveStore.Entity.Product;
using HiveStore.IRepository.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiveStore.Repository.Product
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly HiveDataContext HiveDataContext;
        public ProductRepository(HiveDataContext hiveDataContext) : base(hiveDataContext)
        {
            HiveDataContext = hiveDataContext;
        }

        public void AddProduct(ProductEntity productEntity)
        {
            if (productEntity == null)
            {
                throw new ArgumentNullException("employeeEntity");
            }

            var set = HiveDataContext.Set<ProductEntity>();
            set.Add(productEntity);
        }

        public List<ProductEntity> GetAllProducts()
        {
            return HiveDataContext.Set<ProductEntity>().Where(x => !x.IsDeleted).ToList();
        }

        public ProductEntity GetProductById(int productId)
        {
            return HiveDataContext.Set<ProductEntity>().FirstOrDefault(x => x.Id.Equals(productId));
        }
    }
}
