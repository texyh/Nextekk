using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.Db;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;

namespace ClientManagement.Tests.Core.EmployeeTest
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
            [TestMethod, TestCategory(IntegrationTest)]
            public void Should_Be_Able_To_Add_Employee_To_DB()
            {
                using (var context = new ClientManagementContext())
                using (var repo = new EmployeeRepository(context))
                using (var txn = context.Database.BeginTransaction())
                {
                    var employee = EmployeeData.Employees[0];
                    

                    repo.Create(employee);

                    var dbEmployee = context.Set<Employee>().FirstOrDefault(x => x.Firstname == "James");
        
                    txn.Rollback();

                    Assert.IsNotNull(dbEmployee);
                }
            }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Retrieve_All_Employees_From_DB()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new EmployeeRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                context.Set<Employee>().Add(EmployeeData.Employees[1]);
                context.SaveChanges();
            
                var employees = repo.GetAllEmployees();

                txn.Rollback();

                // Have one Employee already in the database
                // so the number increases by one.
                Assert.AreEqual(2, employees.Count);
            }
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Assign_Project_To_An_Employee()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new EmployeeRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                // Already added projects and employee to the database.
                var employee = context.Set<Employee>().First();
                
                var project = context.Set<Project>().First();
               

                
                repo.AssignProject(employee.Id, project.Id);
                
                

                txn.Rollback();

                Assert.AreEqual(1, employee.Projects.Count);
            }
        }


        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Update_An_Employee()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new EmployeeRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                var employee = EmployeeData.Employees[0];


                repo.Create(employee);

                employee.Lastname = "Emeka";
                repo.Update(employee);
                var dbEmployee = context.Set<Employee>().FirstOrDefault(x => x.Firstname == "James");

                txn.Rollback();

                Assert.AreEqual("Emeka", dbEmployee.Lastname);
            }
        }


    }
}
