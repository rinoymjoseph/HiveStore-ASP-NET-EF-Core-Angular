using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiveStore.DataAccess;
using HiveStore.DataAccess.Product.Repository;
using HiveStore.DataAccess.Product.Repository.Interface;
using HiveStore.Entity.Product;
using HiveStoreNGCoreApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HiveStoreNGCoreApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("ProductAPI")]
    public class ProductController : Controller
    {
        private readonly HiveDataContext _dataContext;
        private readonly IConfiguration _configuration;

        public ProductController(HiveDataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<ProductEntity> productList;

            try
            {
                IProductRepository productRepository = new ProductRepository(_dataContext);
                productList = productRepository.GetAllProducts();
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(productList);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

        [Route("SaveProduct")]
        [HttpPost]
        public IActionResult SaveProduct([FromBody] ProductEntity productEntity)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            try
            {
                IProductRepository productRepository = new ProductRepository(_dataContext);
                if (productEntity.Id > 0)
                {
                    ProductEntity productEntity_saved = productRepository.GetProductById(productEntity.Id);
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
                    productRepository.AddProduct(productEntity);
                }
                productRepository.SaveChanges();
                baseResponseDTO.IsSuccess = true;
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

    }
}