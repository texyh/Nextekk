using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Core.Models
{
    public class Project
    {
        public Project()
        {
            Employees = new List<Employee>();
        }
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid ClientId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public void AddEmploye (Employee employeeEntity)
        {
            if (CantAddEmployee(employeeEntity))
                throw new EmployeeExistException("Employee Already Added to Project");

            Employees.Add(employeeEntity);
        }

        public int NumberOfEmployees()
        {
            return Employees.Count;
        }

        public bool CantAddEmployee(Employee employee)
        {
            return Employees.Contains(employee);

        }

    }

    
}
