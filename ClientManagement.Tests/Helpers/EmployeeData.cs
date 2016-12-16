using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;

namespace ClientManagement.Tests.Helpers
{
    class EmployeeData
    {
        public static Guid User1Id
        {
            get
            {
                return new Guid("ab0db2b1-2b62-4aef-8781-454fe93e7f85");
            }
        }

        public static Guid User2Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }

     

        public static List<Employee> Employees
        {
            get
            {
                return new List<Employee>
                {
                    new Employee { Id = User1Id, Firstname = "James", Lastname = "Don", Gender=Gender.Male },
                    new Employee { Id = User2Id, Firstname = "Lola", Lastname = "Igwe", Gender=Gender.Female}
                };
            }
        }

        public static Employee employee
        {
            get
            {


                return new Employee { Id = User1Id, Firstname = "James", Lastname = "Don", Gender = Gender.Male, ApplicationUserId = "oo221934" };
               
            }
        }

        public static Employee employee2
        {
            get
            {


                return new Employee { Id = User2Id, Firstname = "James", Lastname = "Don", Gender = Gender.Female };

            }
        }

        public static EmployeeProject employeeProject
        {
            get
            {
                return new EmployeeProject { EmployeeId = User1Id, ProjectId = User2Id };
            }
        }
    }
}

