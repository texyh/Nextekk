using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories;

namespace ClientManagement.Core.Services
{
    public class EmployeeServices
    {
        private IEmployeeRepository _employeerepository;

        public EmployeeServices(IEmployeeRepository employeerepository)
        {
            _employeerepository = employeerepository;
        }
        public List<Employee> GetAllEmployees()
        {
            var employees = _employeerepository.GetAllEmployees();
            return employees;
           
        }

        public Employee GetEmployee(Guid Id)
        {
            var employees = GetAllEmployees();
            var employee = employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        /*
        public void AssignProjectToEmployee(Employee employee,Project project)
        {
           
            employee.AssignProject(project);
        }

        public void RemoveEmployeeFromProject(Employee employee,Project project)
        {
            employee.RemoveProject(project);
        }
        */

        public ICollection<Project> EmployeeProjects(Guid employeeId)
        {
            var employee = GetEmployee(employeeId);
            var employeeProjects = employee.GetProjects();
            return employeeProjects;
        }


    }
}
