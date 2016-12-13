using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Services
{
    public interface IEmployeeServices
    {
        void AssignProjectToEmployee(EmployeeProject employeeProject);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(Guid Id);
        Employee GetEmployeeByAppId(string Id);
        void Save(Employee employee);
        Employee GetEmployeeWithProjects(Guid Id);
        List<Project> GetProjects();
    }
}