using HiveStore.DataAccess;
using HiveStore.Entity.Employee;
using HiveStore.IRepository.Employee;
using HiveStore.IService.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository EmployeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public void SaveEmployee(EmployeeEntity employeeEntity)
        {
            try
            {
                if (employeeEntity.Id > 0)
                {
                    EmployeeEntity employeeEntity_saved = EmployeeRepository.GetEmployeeById(employeeEntity.Id);
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
                    EmployeeRepository.AddEmployee(employeeEntity);
                }
                EmployeeRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<EmployeeEntity> GetAllEmployees()
        {
            return EmployeeRepository.GetAllEmployees();
        }

        public EmployeeEntity GetEmployeeById(int employeeId)
        {
            return EmployeeRepository.GetEmployeeById(employeeId);
        }
    }
}
