using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Services
{
    public interface IEmployeeServices
    {
        void AssignProjectToEmployee(Guid employeeID, Guid projectid);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(Guid Id);
        Employee GetEmployeeByAppId(string Id);
        void Save(Employee employee);
        Employee GetEmployeeWithProjects(Guid Id);



    }
}