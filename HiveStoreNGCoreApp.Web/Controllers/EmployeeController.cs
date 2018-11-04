using HiveStore.DTO;
using HiveStore.Entity.Employee;
using HiveStore.IService.Employee;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiveStoreNGCoreApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("EmployeeAPI")]
    public class EmployeeController : Controller
    {
        private IEmployeeService EmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [Route("GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<EmployeeEntity> empolyeeList;

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