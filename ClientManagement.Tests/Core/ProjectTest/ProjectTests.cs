using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Tests.Core.ProjectTest
{
    [TestClass]
    public class ProjectTests
    {
        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_A_Project_Instance()
        {
            var project = new Project();
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Guid_Instance_As_Project_Id()
        {
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";


            Assert.IsInstanceOfType(project.Id, typeof(Guid));
        }

        [TestMethod, TestCategory(UnitTest)]

        public void Should_Return_Correct_ProjectTitle()
        {
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";

            Assert.AreEqual(project.Title, "Renovation of classromm blocks for uyo primary school");
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Correct_Typeof_Project_status()
        {
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            Assert.IsInstanceOfType(project.Status, typeof(ProjectStatus));
        }



        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Add_Employees_To_Project()
        {
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            project.Employees.Add(EmployeeData.employee);
            project.Employees.Add(EmployeeData.employee2);

            Assert.AreEqual(2, project.Employees.Count);
        }


    }
}

