using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Repositories;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Repositories.FileSystem;
using ClientManagement.Core.Models;
using System.IO;
using Newtonsoft.Json;

namespace ClientManagement.Tests.Core.ClientTest
{
    [TestClass]
    public class ClientFileSystemRepositoryTest
    {
        private readonly static string File_Path = ConfigurationManager.AppSettings["ClientFilePath"];


        [TestInitialize]
        public void InitTest()
        {
            var clients = ClientData.Clients;

            File.WriteAllText(File_Path, JsonConvert.SerializeObject(clients, Formatting.Indented));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.WriteAllText(File_Path, string.Empty);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Create_ClientRepository_Instance()
        {
            var repo = new ClientFileSystemRepository();

            Assert.IsNotNull(repo);

        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Save_Client()
        {
            var repo = new ClientFileSystemRepository();
            var client = new Client();
            client.Name = "NNPC";
            client.Address = "Bethel plaza,enugu state";
            repo.Create(client);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Read_All_Cients()
        {
            var repo = new ClientFileSystemRepository();
            var clients = repo.GetAllClients();

            Assert.AreEqual(2, clients.Count);
            Assert.AreEqual(ClientData.client1Id, clients.First().Id);
            Assert.AreEqual(ClientData.client2Id, clients[1].Id);
            Assert.AreEqual("Ministry of Petroluem Resources", clients.First().Name);
        }



    }
}
