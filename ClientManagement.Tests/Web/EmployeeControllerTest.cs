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
            //.AreEqual(2, model);
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Create_Should_A_New_Employee()
        {
            var employeeController = new EmployeeController(_employeeServiceMock.Object);

            var result = employeeController.Create(EmployeeData.employee);

            

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            
        }
    }


}
