using HiveStore.DataAccess;
using HiveStore.Entity.Employee;
using HiveStore.IRepository.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiveStore.Repository.Employee
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly HiveDataContext HiveDataContext;
        public EmployeeRepository(HiveDataContext hiveDataContext) : base(hiveDataContext)
        {
            HiveDataContext = hiveDataContext;
        }

        public void AddEmployee(EmployeeEntity employeeEntity)
        {
            if (employeeEntity == null)
            {
                throw new ArgumentNullException("employeeEntity");
            }

            var set = HiveDataContext.Set<EmployeeEntity>();
            set.Add(employeeEntity);
        }

        public List<EmployeeEntity> GetAllEmployees()
        {
            return HiveDataContext.Set<EmployeeEntity>().Where(x => !x.IsDeleted).ToList();
        }

        public EmployeeEntity GetEmployeeById(int employeeId)
        {
            return HiveDataContext.Set<EmployeeEntity>().FirstOrDefault(x => x.Id.Equals(employeeId));
        }
    }
}
