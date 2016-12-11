using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using static ClientManagement.Tests.Constants;
using ClientManagement.Tests.Helpers;
using Moq;
using ClientManagement.Core.Repositories;
using ClientManagement.Core.Services;
using ClientManagement.Core.Exceptions;
using ClientManagement.Core.Repositories.FileSystem;



namespace ClientManagement.Tests.Core.ProjectTest
{
    [TestClass]
    public class ProjectServiceTest
    {
        private Mock<IProjectRepository> _projectRepoMock;

        [TestInitialize]
        public void BeforeEach()
        {

            var projects = ProjectData.Projects;
            _projectRepoMock = new Mock<IProjectRepository>();
            _projectRepoMock.Setup(x => x.GetAllProjects()).Returns(projects);
            _projectRepoMock
                 .Setup(x => x.GetProject(It.IsAny<Guid>()))
                .Returns((Guid input) =>
                {
                    return projects.FirstOrDefault(y => y.Id == input);
                });
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_A_ProjectService_Instance()
        {
            var projectService = new ProjectServices(_projectRepoMock.Object);

            Assert.IsNotNull(projectService);
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_A_Project()
        {
            var projectService = new ProjectServices(_projectRepoMock.Object);
            var project = projectService.GetProject(ProjectData.Project1Id);
            
            //Assert.IsInstanceOfType(project.Status, typeof(ProjectStatus));
            //Assert.AreEqual("Rehabilitation of uyo high school", project.Description);
            Assert.IsInstanceOfType(project, typeof(Project));

        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_An_All_Projects()
        {
            var projectService = new ProjectServices(_projectRepoMock.Object);
            var projects = projectService.GetAllProjects();
            Assert.IsInstanceOfType(projects, typeof(List<Project>));
            Assert.AreEqual(2, projects.Count);
        }




    }
}
