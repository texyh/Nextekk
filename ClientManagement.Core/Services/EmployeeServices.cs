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
        private IEmployeerepository _employeerepository;

        public EmployeeServices(IEmployeerepository employeerepository)
        {
            _employeerepository = employeerepository;
        }
        public List<Employee> GetAllEmployees()
        {
            var employeeEntity = _employeerepository.GetAllEmployees();
            var employees = employeeEntity.Select(x => ToEmployee(x)).ToList();
            return employees;
           
        }

        public Employee GetEmployee(Guid Id)
        {
            var employees = GetAllEmployees();
            var employee = employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public Employee ToEmployee(EmployeeEntity employeeEntity)
        {
            var employee = new Employee();
            employee.Id = employeeEntity.Id;
            employee.Firstname = employeeEntity.Firstname;
            employee.Lastname = employeeEntity.Lastname;
            employee.Gender = employeeEntity.Gender;
            return employee;
        }

     
        public void AssignProjectToEmployee(Employee employee,ProjectEntity project)
        {
           
            employee.AssignProject(project);
        }

        public void RemoveEmployeeFromProject(Guid EmployeeId, ProjectEntity project)
        {
            var employee = GetEmployee(EmployeeId);
            employee.RemoveProject(project);
        }

    }
}
