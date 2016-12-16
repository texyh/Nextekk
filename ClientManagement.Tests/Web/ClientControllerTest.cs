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
    public class ClientControllerTest
    {
        private Mock<IClientServices> _clientServiceMock;

        [TestInitialize]
        public void BeforeEach()
        {
            _clientServiceMock = new Mock<IClientServices>();

            var Clients = ClientData.Clients;
            _clientServiceMock
                .Setup(x => x.GetAllClients())
                .Returns(Clients);

            _clientServiceMock
                .Setup(x => x.GetClient(It.IsAny<Guid>()))
                .Returns((Guid input) => {
                    return Clients.Find(x => x.Id == input);
                });
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Index_Returns_All_Clients()
        {
            var clientController = new ClientController(_clientServiceMock.Object);

            var result = clientController.Index();
            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(IEnumerable<Client>));
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Create_Should_Create_A_New_Client()
        {
            var clientController = new ClientController(_clientServiceMock.Object);
            var client = ClientData.client;


            var result = clientController.Create(client);
            _clientServiceMock.Verify(x => x.Save(client), Times.Once);

        }

    }
}
