using HiveStore.DTO;
using HiveStore.Entity.Product;
using HiveStore.IHelper;
using HiveStore.IService.Product;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("ProductAPI")]
    public class ProductController : ControllerBase
    {
        private IProductService ProductService;
        private IRequestInfoHelper RequestInfoHelper;

        public ProductController(IProductService productService, IRequestInfoHelper requestInfoHelper)
        {
            ProductService = productService;
            RequestInfoHelper = requestInfoHelper;
        }

        [HiveStoreAuthorize]
        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<ProductEntity> productList;
            RequestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

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

        [HiveStoreAuthorize]
        [Route("SaveProduct")]
        [HttpPost]
        public IActionResult SaveProduct([FromBody] ProductEntity productEntity)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            RequestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

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