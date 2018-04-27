using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiveStore.DataAccess;
using HiveStore.DataAccess.Employee.Repository;
using HiveStore.DataAccess.Employee.Repository.Interface;
using HiveStore.Entity.Employee;
using HiveStoreNGCoreApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HiveStoreNGCoreApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("EmployeeAPI")]
    public class EmployeeController : Controller
    {
        public readonly HiveDataContext _dataContext;
        public EmployeeController(HiveDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<EmployeeEntity> empolyeeList;

            try
            {
                IEmployeeRepository empRepository = new EmployeeRepository(_dataContext);
                empolyeeList = empRepository.GetAllEmployees();
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
                IEmployeeRepository empRepository = new EmployeeRepository(_dataContext);
                employeeEntity.CreatedBy = System.Environment.UserName;
                employeeEntity.ModifiedBy = System.Environment.UserName;
                employeeEntity.CreatedDate = DateTime.Now;
                employeeEntity.ModifiedDate = DateTime.Now;
                empRepository.AddEmployee(employeeEntity);
                empRepository.SaveChanges();
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