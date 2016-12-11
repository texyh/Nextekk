using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(Guid Id);
        void Update(Employee employee);
        void AssignProject(Guid employeeId, Guid projectId);
        Project GetProject(Guid Id);
        Employee GetEmployeeWithProjects(Guid Id);



    }
}