using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ClientManagement.Tests.Constants;
using ClientManagement.Core.Models;
using ClientManagement.Core.Exceptions;
using ClientManagement.Tests.Helpers;
using System.Collections.Generic;

namespace ClientManagement.Tests.Core.ClientTest
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_A_Client_Instance()
        {
            var client = new Client();
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Guid_Instance_As_Client_Id()
        {
            var client = new Client();
            client.Id = Guid.NewGuid();
            client.ClientName = "Ministry of Petroleum Resources";
            client.Address = "Plot 143 summer street kubwa";
       
            Assert.IsInstanceOfType(client.Id, typeof(Guid));
        }

        [TestMethod, TestCategory(UnitTest)]

        public void Should_Return_Correct_ClientName()
        {
            var client = new Client();
            client.Id = Guid.NewGuid();
            client.ClientName = "Ministry of Petroleum Resources";
            client.Address = "Plot 143 summer street kubwa";
            Assert.AreEqual(client.ClientName, "Ministry of Petroleum Resources");
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Return_Correct_Address()
        {
            var client = new Client();
            client.Id = Guid.NewGuid();
            client.ClientName = "Ministry of Petroleum Resources";
            client.Address = "Plot 143 summer street kubwa";
            Assert.AreEqual(client.Address, "Plot 143 summer street kubwa");
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Add_Projects_To_Client()
        {

            var client = new Client();
            client.Id = Guid.NewGuid();
            client.ClientName = "Ministry of Petroleum Resources";
            client.Address = "Plot 143 summer street kubwa";
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            client.AddProject(project);
            Assert.AreEqual(1, client.NumberOfProjects());
        }


        [TestMethod, TestCategory(UnitTest)]
        [ExpectedException(typeof(ProjectExistException))]
        public void Should_Not_Be_Able_To_Add_OneProjects_Twice_To_Client()
        {

            var client = new Client();
            client.Id = Guid.NewGuid();
            client.ClientName = "Ministry of Petroleum Resources";
            client.Address = "Plot 143 summer street kubwa";
            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            client.AddProject(project);
            client.AddProject(project);
        
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_All_Projects_Added_To_A_Client()
        {
            var client = ClientData.client;

            var project = new Project();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";

            var project2 = ProjectData.project;

            client.AddProject(project);
            client.AddProject(project2);

            Assert.AreEqual(2, client.NumberOfProjects());
            Assert.IsInstanceOfType(client.GetProjects(), typeof(List<Project>));

        }
    }
}
