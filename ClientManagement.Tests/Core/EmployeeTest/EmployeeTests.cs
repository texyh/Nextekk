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
        [TestMethod,TestCategory(UnitTest)]
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
        public void Should_Be_Able_To_Assign_Projects_To_An_Employee()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            employee.AssignProject(ProjectData.project);

            Assert.AreEqual(1,employee.NumberOfProjects());
        }


        [TestMethod, TestCategory(UnitTest)]
        [ExpectedException(typeof(ProjectExistException))]
        public void Should_Not_Be_Able_To_Assign_A_Project_More_Than_Once_To_An_Employee()
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
            employee.AssignProject(project);
            employee.AssignProject(project);
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Remove_Projects()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender=Gender.Male;
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            employee.AssignProject(project);
            employee.RemoveProject(project);
            
            Assert.AreEqual(0, employee.NumberOfProjects());
        }


        [TestMethod, TestCategory(UnitTest)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_Not_Be_Able_To_Remove_Unassigned_Projects()
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
            employee.RemoveProject(project);
     
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrive_Projects_An_Employee_Is_Working_on()
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Firstname = "Emeka";
            employee.Lastname = "Onwuzulike";
            employee.Gender = Gender.Male;
            employee.AssignProject(ProjectData.project);
            employee.AssignProject(ProjectData.project2);
            var employeeProjects = employee.GetProjects();
            Assert.IsInstanceOfType(employeeProjects, typeof(List<Project>));
            //Assert.AreEqual(employeeProjects[1].Title, "Construction of hostel");



        }

    }
}
