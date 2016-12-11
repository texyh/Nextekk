﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories;

namespace ClientManagement.Core.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeServices(IEmployeeRepository employeerepository)
        {
            _employeeRepository = employeerepository;
        }


        public List<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return employees;
        }

        public Employee GetEmployee(Guid Id)
        {
            var employees = GetAllEmployees();
            var employee = employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }


        public Employee GetEmployeeByAppId(string Id)
        {
            var employees = GetAllEmployees();
            var employee = employees.FirstOrDefault(x => x.ApplicationUserId == Id);
            return employee;
        }


        public void Save(Employee employee)
        {
            var dbEmployee = _employeeRepository.GetEmployee(employee.Id);

            if (dbEmployee == null)
                _employeeRepository.Create(employee);
            else
                _employeeRepository.Update(employee);
        }


        public void AssignProjectToEmployee(Guid employeeId, Guid projectid)
        {
            _employeeRepository.AssignProject(employeeId, projectid);

        }

        //public void RemoveEmployeeFromProject(Employee employee,Project project)
        //{
        //    employee.RemoveProject(project);
        //}


        //Includes Navigation Properties
        public Employee GetEmployeeWithProjects(Guid Id)
        {
            var employee = _employeeRepository.GetEmployeeWithProjects(Id);
            return employee;
        }

    }
}
