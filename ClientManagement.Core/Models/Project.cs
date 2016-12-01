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
            Employees = new List<EmployeeEntity>();
        }
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public ClientEntity Client { get; set; }

        public ProjectStatus Status { get; set; }
        private List<EmployeeEntity> Employees { get; set; }

        public void AddEmploye (EmployeeEntity employeeEntity)
        {
            if (CantAddEmployee(employeeEntity))
                throw new EmployeeExistException("Employee Already Added to Project");

            Employees.Add(employeeEntity);
        }

        public int NumberOfEmployees()
        {
            return Employees.Count;
        }

        public bool CantAddEmployee(EmployeeEntity employee)
        {
            return Employees.Contains(employee);

        }

    }

    
}
