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

namespace ClientManagement.Tests.Core.EmployeeTest
{
    
    [TestClass]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeerepository> _employeeRepoMock;

        [TestInitialize]
        public void BeforeEach()
        {

            var employees = EmployeeData.EmployeeEntities;
            _employeeRepoMock = new Mock<IEmployeerepository>();
            _employeeRepoMock.Setup(x => x.GetAllEmployees()).Returns(employees);
            _employeeRepoMock
                .Setup(x => x.GetEmployee(It.IsAny<Guid>()))
                .Returns((Guid input) =>
                {
                    return employees.FirstOrDefault(y => y.Id == input);
                });
        }

        [TestMethod,TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_An_EmployeeService_Instance()
        {
            var employeeService = new EmployeeServices(_employeeRepoMock.Object);

            Assert.IsNotNull(employeeService);
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_An_Employee()
        {
            var employeeService = new EmployeeServices(_employeeRepoMock.Object);
            var employee = employeeService.GetEmployee(EmployeeData.User2Id);
            Assert.AreEqual("Chinyere", employee.Firstname);
            Assert.IsInstanceOfType(employee, typeof(Employee));

        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_An_All_Employees()
        {
            var employeeService = new EmployeeServices(_employeeRepoMock.Object);
            var employees = employeeService.GetAllEmployees();
            Assert.AreEqual(2, employees.Count);
            Assert.IsInstanceOfType(employees, typeof(List<Employee>));
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_ToAssign_An_ProjectEmployee_To_A_()
        {
            var employeeService = new EmployeeServices(_employeeRepoMock.Object);
            var employee = EmployeeData.Employees[0];
            employeeService.AssignProjectToEmployee(employee, ProjectData.project);
            Assert.AreEqual(1,employee.NumberOfProjects());
        }

        [TestMethod, TestCategory(UnitTest)]
        [ExpectedException(typeof(ProjectExistException))]
        public void Should_Be_Able_TAssign_An_ProjectEmployee_To_A_()
        {
            var employeeService = new EmployeeServices(_employeeRepoMock.Object);
            var employee = EmployeeData.Employees[0];
            var project = new ProjectEntity();
            project.Id = Guid.NewGuid();
            project.Status = ProjectStatus.Completed;
            project.Description = "Renovation of classroom blocks";
            project.Title = "Renovation of classromm blocks for uyo primary school";
            employeeService.AssignProjectToEmployee(employee, project);
            employeeService.AssignProjectToEmployee(employee, project);
        }



    }
}
