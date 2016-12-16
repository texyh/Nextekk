using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientManagement.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClientManagement.Web.Controllers;
using System.Web.Mvc;
using ClientManagement.Core.Models;
using ClientManagement.Core.Services;
using ClientManagement.Tests.Helpers;

namespace ClientManagement.Tests.Web
{
    [TestClass]
    public class ProjectControllerTest
    {

        private Mock<IProjectServices> _projectServiceMock;

        [TestInitialize]
        public void BeforeEach()
        {
            _projectServiceMock = new Mock<IProjectServices>();

            var Projects = ProjectData.Projects;
            _projectServiceMock
                .Setup(x => x.GetAllProjects())
                .Returns(Projects);

            _projectServiceMock
                .Setup(x => x.GetProject(It.IsAny<Guid>()))
                .Returns((Guid input) => {
                    return Projects.Find(x => x.Id == input);
                });
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Index_Returns_All_Projects()
        {
            var projectController = new ProjectController(_projectServiceMock.Object);

            var result = projectController.Index();
            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(IEnumerable<Project>));
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Create_Should_Create_A_New_Project()
        {
            var projectController = new ProjectController(_projectServiceMock.Object);
            var project = ProjectData.project;

            
            var result = projectController.Create(project);
            _projectServiceMock.Verify(x => x.Save(project), Times.Once);

        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Edit_Project()
        {
            var projectController = new ProjectController(_projectServiceMock.Object);
            var project = ProjectData.project;


            var result = projectController.Edit(project);
            _projectServiceMock.Verify(x => x.Save(project), Times.Once);

        }



        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Returns_All_Projects_Employees()
        {
            var projectController = new ProjectController(_projectServiceMock.Object);
            var project = ProjectData.project;

            var result = projectController.ProjectEmployees(project.Id);
            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            _projectServiceMock.Verify(x => x.ProjectEmployees(project.Id), Times.Once);

        }
    }
}
