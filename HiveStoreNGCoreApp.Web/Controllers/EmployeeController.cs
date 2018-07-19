using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using HiveStore.DataAccess;
using HiveStore.DataAccess.Employee.Repository;
using HiveStore.DataAccess.Employee.Repository.Interface;
using HiveStore.Entity.Employee;
using HiveStoreNGCoreApp.Web.Helpers;
using HiveStoreNGCoreApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HiveStoreNGCoreApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("EmployeeAPI")]
    public class EmployeeController : Controller
    {
        private readonly HiveDataContext _dataContext;
        private readonly IConfiguration _configuration;

        public EmployeeController(HiveDataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
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
                if (employeeEntity.Id > 0)
                {
                    EmployeeEntity employeeEntity_saved = empRepository.GetEmployeeById(employeeEntity.Id);
                    employeeEntity_saved.FirstName = employeeEntity.FirstName;
                    employeeEntity_saved.LastName = employeeEntity.LastName;
                    employeeEntity_saved.Country = employeeEntity.Country;
                    employeeEntity_saved.City = employeeEntity.City;
                    employeeEntity.ModifiedBy = System.Environment.UserName;
                    employeeEntity.ModifiedDate = DateTime.Now;
                }
                else
                {
                    employeeEntity.CreatedBy = System.Environment.UserName;
                    employeeEntity.ModifiedBy = System.Environment.UserName;
                    employeeEntity.CreatedDate = DateTime.Now;
                    employeeEntity.ModifiedDate = DateTime.Now;
                    empRepository.AddEmployee(employeeEntity);
                }                 
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


        [Route("TestFileDownload")]
        [HttpGet]
        public IActionResult TestFileDownload()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();

            try
            {

            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

        [Route("TestFileTransfer")]
        [HttpPost]
        public IActionResult TestFileTransfer()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            try
            {
                var form = Request.Form;
                var attachments = new List<IFormFile>(form.Files);
                IFormFile receiptfile = attachments.First();
                string filePath = _configuration?.GetSection("AppSettings")?["File_Path"] + receiptfile.FileName;

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                var fileStream = receiptfile.OpenReadStream();
                SendReceiptCreationMail(new Attachment(fileStream, receiptfile.FileName));

                //using (var fileStream = receiptfile.OpenReadStream())
                //{
                //    SendReceiptCreationMail(new Attachment(fileStream, receiptfile.FileName));
                //}

                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    receiptfile.CopyTo(fileStream);
                //}
                //SendReceiptCreationMail(new Attachment(filePath));
                //using (var stream = System.IO.File.OpenWrite(filePath))
                //{
                //    await receiptfile.CopyToAsync(stream);
                //}
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

        private void SendReceiptCreationMail(Attachment attachment)
        {
            string strFrom = "";
            if (!string.IsNullOrEmpty(_configuration?.GetSection("AppSettings")?["FromEmail"]))
            {
                strFrom = _configuration?.GetSection("AppSettings")?["FromEmail"];
            }

            string strTo = "";
            if (!string.IsNullOrEmpty(_configuration?.GetSection("AppSettings")?["ToEmail"]))
            {
                strTo = _configuration?.GetSection("AppSettings")?["ToEmail"];
            }

            string strSubject = "";
            if (!string.IsNullOrEmpty(_configuration?.GetSection("AppSettings")?["Subject"]))
            {
                strSubject = _configuration?.GetSection("AppSettings")?["Subject"];
            }
            string body = "Hello Engineer! \n\n Received RawMaterial Part Number: on " + DateTime.Now.ToString("dd-MM-yyyy") +
                ". \n Please verify them and update the status in Qualification Inventory portal.\n\n Thanks & regards\n PRSD Qualification Inventory Team.";


            var smtpAddr = _configuration?.GetSection("AppSettings")?["SMTPAddress"];

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(strFrom);
            mailMessage.To.Add(new MailAddress(strTo));
            mailMessage.Subject = strSubject;
            mailMessage.Attachments.Add(attachment);
            mailMessage.Body = body;
            mailMessage.Priority = MailPriority.Normal;
            SmtpClient smtpClient = new SmtpClient(smtpAddr);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(mailMessage);
        }
    }
}