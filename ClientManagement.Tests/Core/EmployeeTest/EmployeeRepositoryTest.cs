using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Repositories;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using System.IO;
using Newtonsoft.Json;


namespace ClientManagement.Tests
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private readonly static string File_Path = ConfigurationManager.AppSettings["EmployeeFilePath"];


        [TestInitialize]
        public void InitTest()
        {
            var employees = EmployeeData.EmployeeEntities;

            File.WriteAllText(File_Path, JsonConvert.SerializeObject(employees, Formatting.Indented));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.WriteAllText(File_Path, string.Empty);
        }


        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Create_Employeerepository_Instance()
        {
            var repo = new EmployeeFileSystemRepository();

            Assert.IsNotNull(repo);

        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Save_Employee()
        {
            var repo = new EmployeeFileSystemRepository();
            var employee = new Employee();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulke";
            employee.Gender = Gender.Female;
          repo.Create(employee);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Read_All_Employees()
        {
            var repo = new EmployeeFileSystemRepository();
            var employees = repo.GetAllEmployees();

            Assert.AreEqual(2, employees.Count);
            Assert.AreEqual(EmployeeData.User1Id, employees.First().Id);
            Assert.AreEqual(EmployeeData.User2Id, employees[1].Id);
        }


        


    }
}
