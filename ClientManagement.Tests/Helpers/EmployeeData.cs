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

        public static List<EmployeeEntity> EmployeeEntities
        {
            get
            {
                return new List<EmployeeEntity>
                {
                    new EmployeeEntity { Id = User1Id, Firstname = "Emeka", Lastname = "Onwuzulike",Gender="Male"},
                    new EmployeeEntity { Id = User2Id, Firstname = "Chinyere", Lastname = "Okoh",Gender="FeMale" }
                };
            }
        }

        public static List<Employee> Employees
        {
            get
            {
                return new List<Employee>
                {
                    new Employee { Id = User1Id, Firstname = "James", Lastname = "Don", Gender="Male" },
                    new Employee { Id = User2Id, Firstname = "Lola", Lastname = "Igwe", Gender="FeMale"}
                };
            }
        }

        public static EmployeeEntity employee
        {
            get
            {


                return new EmployeeEntity { Id = User1Id, Firstname = "James", Lastname = "Don", Gender = "Male" };
               
            }
        }

        public static EmployeeEntity employee2
        {
            get
            {


                return new EmployeeEntity { Id = User2Id, Firstname = "James", Lastname = "Don", Gender = "Male" };

            }
        }
    }
}

