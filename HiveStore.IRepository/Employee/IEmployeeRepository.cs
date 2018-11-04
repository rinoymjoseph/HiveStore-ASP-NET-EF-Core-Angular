using HiveStore.Entity.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.IRepository.Employee
{
    public interface IEmployeeRepository
    {
        void AddEmployee(EmployeeEntity employeeEntity);
        List<EmployeeEntity> GetAllEmployees();
        EmployeeEntity GetEmployeeById(int employeeId);
        string SaveChanges();
    }
}
