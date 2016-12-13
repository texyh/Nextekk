using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using System.Data.Entity;

namespace ClientManagement.Core.Repositories.Db
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
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


        

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(Guid Id)
        {
            return _context.Employees.Find(Id);
        }

        //Includes Navigation Properties
        public Employee GetEmployeeWithProjects(Guid Id)
        {
            var employee = _context.Employees.Include(e => e.Projects).FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public Project GetProject(Guid Id)
        {
            return _context.Projects.Find(Id);

        }

        public List<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public void Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        public void Update(Employee employee)
        {
            var dbEmployee = GetEmployee(employee.Id);
            dbEmployee.Lastname = employee.Lastname;
            dbEmployee.Firstname = employee.Firstname;
            dbEmployee.Gender = employee.Gender;
            _context.SaveChanges();

        }

        public void AssignProject(Guid employeeId, Guid projectId)
        {
            var dbProject = GetProject(projectId);
            var dbEmployee = GetEmployee(employeeId);

            dbEmployee.Projects.Add(dbProject);
            //_context.Entry(dbEmployee).State = System.Data.Entity.EntityState.Modified;
            //_context.Entry(dbEmployee).State = System.Data.Entity.EntityState.Modified;
            //_context.Projects.Attach(dbProject);
            //_context.Employees.Add(dbEmployee);
            //_context.Employees.Attach(dbEmployee);
            //dbEmployee.Projects.Add(dbProject);

            _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
