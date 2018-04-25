using HiveStore.DataAccess.Product.Repository.Interface;
using HiveStore.Entity.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiveStore.DataAccess.Product.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly DbContext _dataContext;
        public ProductRepository(DbContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddProduct(ProductEntity productEntity)
        {
            if (productEntity == null)
            {
                throw new ArgumentNullException("employeeEntity");
            }

            var set = _dataContext.Set<ProductEntity>();
            set.Add(productEntity);
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _dataContext.Set<ProductEntity>().Where(x => !x.IsDeleted).ToList();
        }
    }
}
