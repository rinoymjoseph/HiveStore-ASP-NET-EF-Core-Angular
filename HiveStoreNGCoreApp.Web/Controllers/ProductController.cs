using HiveStore.DTO;
using HiveStore.Entity.Product;
using HiveStore.IService.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiveStoreNGCoreApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("ProductAPI")]
    public class ProductController : Controller
    {

        private IProductService ProductService;

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<ProductEntity> productList;

            try
            {
                productList = ProductService.GetAllProducts();
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
                ProductService.SaveProduct(productEntity);                
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