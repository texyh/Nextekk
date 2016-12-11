using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using static ClientManagement.Tests.Constants;
using ClientManagement.Tests.Helpers;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_An_Employee_Instance()
        {
            var employee = new Employee();
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Guid_Instance_As_Employee_Id()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            Assert.IsInstanceOfType(employee.Id, typeof(Guid));
        }

        [TestMethod, TestCategory(UnitTest)]

        public void Should_Return_Correct_FirstName()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            Assert.AreEqual(employee.Firstname, "Emeka");
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Correct_LastName()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            Assert.AreEqual(employee.Lastname, "Onwuzulike");
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Add_Projects_To_An_Employee()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            employee.Projects.Add(ProjectData.project);

            Assert.AreEqual(1, employee.Projects.Count);
        }




        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Remove_Projects()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            employee.Projects.Add(project);

            employee.Projects.Remove(project);
            Assert.AreEqual(0, employee.Projects.Count);
        }




        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrive_Projects_An_Employee_Is_Working_on()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            employee.Projects.Add(ProjectData.project);
            employee.Projects.Add(ProjectData.project2);
            var employeeProjects = employee.Projects;
            Assert.IsInstanceOfType(employeeProjects, typeof(List<Project>));

        }

    }
}
