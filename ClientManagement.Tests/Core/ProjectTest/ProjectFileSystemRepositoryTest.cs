using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Repositories.FileSystem;
using ClientManagement.Core.Models;
using System.IO;
using Newtonsoft.Json;


namespace ClientManagement.Tests.Core.ProjectTest
{

    [TestClass]
    public class ProjectFileSystemRepositoryTest
    {
        private readonly static string File_Path = ConfigurationManager.AppSettings["ProjectFilePath"];


        [TestInitialize]
        public void InitTest()
        {
            var projects = ProjectData.Projects;

            File.WriteAllText(File_Path, JsonConvert.SerializeObject(projects, Formatting.Indented));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.WriteAllText(File_Path, string.Empty);
        }


        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Create_ProjectRepository_Instance()
        {
            var repo = new ProjectFileSystemRepository();

            Assert.IsNotNull(repo);

        }

        /*[TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Save_Project()
        {
            var repo = new ProjectRepository();
            var project = new Project();
            project.Title = "Design of an Ecommerce store for students";
            project.Description = "Desgin of an Ecommerce store for Nigerian students";
            project.Client = ClientData.clientEntity;
            project.Status = ProjectStatus.InProgress;
            repo.CreateProject(project);
        }*/


        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Read_All_Project()
        {
            var repo = new ProjectFileSystemRepository();
            var projects = repo.GetAllProjects();

            Assert.AreEqual(2, projects.Count);
            //Assert.AreEqual(ProjectData.Project1Id, projects.First().Id);
            //Assert.AreEqual(ProjectData.Project2Id, projects[1].Id);
            //Assert.AreEqual("Rehabilitation of block class rooms", projects.First().Title);
        }
    }
}
