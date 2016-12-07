using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Services
{
    public interface IEmployeeServices
    {
        ICollection<Project> EmployeeProjects(Guid employeeId);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(Guid Id);
        void Save(Employee employee);
    }
}