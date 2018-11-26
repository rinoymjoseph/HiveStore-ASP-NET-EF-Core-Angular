using HiveStore.DTO;
using HiveStore.Entity.Employee;
using HiveStore.IHelper;
using HiveStore.IService.Employee;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("EmployeeAPI")]
    public class EmployeeController : Controller
    {
        private IEmployeeService EmployeeService;
        private IRequestInfoHelper RequestInfoHelper;

        public EmployeeController(IEmployeeService employeeService, IRequestInfoHelper serverInfoHelper)
        {
            EmployeeService = employeeService;
            RequestInfoHelper = serverInfoHelper;
        }

        [Route("GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<EmployeeEntity> empolyeeList;
            RequestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                empolyeeList = EmployeeService.GetAllEmployees();
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(empolyeeList);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

        [Route("SaveEmployee")]
        [HttpPost]
        public IActionResult SaveEmployee([FromBody] EmployeeEntity employeeEntity)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            RequestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                EmployeeService.SaveEmployee(employeeEntity);         
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