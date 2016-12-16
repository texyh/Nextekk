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

namespace ClientManagement.Tests.Core.ClientTest
{
    [TestClass]
    public class ClientServiceTest
    {
        private Mock<IClientRepository> _clientRepoMock;

        [TestInitialize]
        public void BeforeEach()
        {

            var clients = ClientData.Clients;
            _clientRepoMock = new Mock<IClientRepository>();
            _clientRepoMock.Setup(x => x.GetAllClients()).Returns(clients);
            _clientRepoMock
                 .Setup(x => x.GetClientOnly(It.IsAny<Guid>()))
                .Returns((Guid input) =>
                {
                    return clients.FirstOrDefault(y => y.Id == input);
                });
        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Create_A_ClientService_Instance()
        {
            var clientService = new ClientServices(_clientRepoMock.Object);

            Assert.IsNotNull(clientService);
        }

        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_A_Client()
        {
            var clientService = new ClientServices(_clientRepoMock.Object);

            var client = clientService.GetClient(ClientData.client1Id);


            Assert.AreEqual("Ministry of Petroluem Resources", client.Name);
            Assert.IsInstanceOfType(client, typeof(Client));

        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_An_All_Clients()
        {
            var clientService = new ClientServices(_clientRepoMock.Object);

            var clients = clientService.GetAllClients();


            Assert.IsInstanceOfType(clients, typeof(List<Client>));
            Assert.AreEqual(2, clients.Count);
        }



        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Retrieve_All_Projects_Handled_For_A_Client()
        {
            
             var clientService = new ClientServices(_clientRepoMock.Object);
             var ClientProjects =  clientService.GetAllClientProjects(ClientData.client1Id);
            
            
            Assert.IsInstanceOfType(ClientProjects, typeof(List<Project>));

        }


        [TestMethod, TestCategory(UnitTest)]
        public void Should_Be_Able_To_Save_A_Client()
        {

            var clientService = new ClientServices(_clientRepoMock.Object);
            var client = ClientData.client;
            
            clientService.Save(client);

            _clientRepoMock.Verify(x => x.Update(client), Times.Once);
            
        }





    }

}
