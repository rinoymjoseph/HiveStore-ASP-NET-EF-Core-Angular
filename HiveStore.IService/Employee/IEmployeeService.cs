using HiveStore.Entity.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.IService.Employee
{
    public interface IEmployeeService
    {
        void SaveEmployee(EmployeeEntity employeeEntity);
        List<EmployeeEntity> GetAllEmployees();
        EmployeeEntity GetEmployeeById(int employeeId);
    }
}
