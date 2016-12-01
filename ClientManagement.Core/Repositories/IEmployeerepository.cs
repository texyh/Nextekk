using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories
{
    public interface IEmployeerepository
    {
        void CreateEmployee(EmployeeEntity employeeEntity);
        List<EmployeeEntity> GetAllEmployees();
        EmployeeEntity GetEmployee(Guid Id);
        void PersistEmployees();
        void UpdateEmployee(EmployeeEntity employeeEntity);
    }
}