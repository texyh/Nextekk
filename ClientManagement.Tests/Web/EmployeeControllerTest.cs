using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Services;
using ClientManagement.Tests.Helpers;
using ClientManagement.Core.Repositories;
using static ClientManagement.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClientManagement.Web.Controllers;
using System.Web.Mvc;
using ClientManagement.Core.Models;

namespace ClientManagement.Tests.Web
{
    [TestClass]
    public class EmployeeControllerTest
    {

        private Mock<IEmployeeServices> _employeeServiceMock;

        [TestInitialize]
        public void BeforeEach()
        {
            _employeeServiceMock = new Mock<IEmployeeServices>();

            var employees = EmployeeData.Employees;
            _employeeServiceMock
                .Setup(x => x.GetAllEmployees())
                .Returns(employees);

            _employeeServiceMock
                .Setup(x => x.GetEmployee(It.IsAny<Guid>()))
                .Returns((Guid input) => {
                    return employees.Find(x => x.Id == input);
                });
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Index_Returns_All_Employees()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);

            var result = employeeController.Index();
            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(IEnumerable<Employee>));
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Create_Should_Create_A_New_Employee()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);
            var employee = EmployeeData.employee;


            var result = employeeController.Create(employee);
            _employeeServiceMock.Verify(x => x.Save(employee), Times.Once);
  
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Assign_Project_To_Employee()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);
            var employeeProject = EmployeeData.employeeProject;


            var result = employeeController.AssignProject(employeeProject);
            _employeeServiceMock.Verify(x => x.AssignProjectToEmployee(employeeProject), Times.Once);
            
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Remove_Employee_From()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);
            var employeeProject = EmployeeData.employeeProject;


            var result = employeeController.RemoveProject(employeeProject);
            _employeeServiceMock.Verify(x => x.RemoveEmployeeFromProject(employeeProject), Times.Once);

        }



        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Edit_Employee()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);
            var employee = EmployeeData.employee;


            var result = employeeController.Edit(employee);
            _employeeServiceMock.Verify(x => x.Save(employee), Times.Once);

        }



    }


}
