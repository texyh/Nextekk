using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories.Db
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ClientManagementContext _context;
        private readonly bool _externalContext;

        public EmployeeRepository()
        {
            _context = new ClientManagementContext();
        }

        public EmployeeRepository(ClientManagementContext context)
        {
            _context = context;
            _externalContext = true;
        }

        
        public void Create(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployee(Guid Id)
        {
            return _context.Employee.Find(Id);
        }


        public void Update(Employee employee)
        {
            var dbEmployee = GetEmployee(employee.Id);
            dbEmployee.Lastname = employee.Lastname;
            dbEmployee.Firstname = employee.Firstname;
            dbEmployee.Gender = dbEmployee.Gender;

        }
    }
}
