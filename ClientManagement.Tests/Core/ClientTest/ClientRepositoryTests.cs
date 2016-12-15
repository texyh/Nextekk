using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.Db;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;

namespace ClientManagement.Tests.Core.ClientTest
{
    [TestClass]
    public class ClientRepositoryTests
    {
        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Add_Client_To_DB()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new ClientRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                var client = ClientData.client;


                repo.Create(client);

                var dbClient = context.Set<Client>().FirstOrDefault(x => x.Name == "Ministry of Petroluem Resources");

                txn.Rollback();

                Assert.IsNotNull(dbClient);
            }
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Retrieve_All_Clients_From_DB()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new ClientRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                context.Set<Client>().Add(ClientData.Clients[1]);
                context.SaveChanges();

                var clients = repo.GetAllClients();

                txn.Rollback();

                // I already have one client in the database.
                // So the number increases by one
                Assert.AreEqual(2, clients.Count);
            }
        }


        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Update_A_Client()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new ClientRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                var client = ClientData.client;


                repo.Create(client);
                client.Address = "Bethel Plaza";

                var dbClient = context.Set<Client>().FirstOrDefault(x => x.Name == "Ministry of Petroluem Resources");

                txn.Rollback();

                Assert.AreEqual("Bethel Plaza", dbClient.Address);
            }
        }
    }
}
