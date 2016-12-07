using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;

namespace ClientManagement.Tests.Helpers
{
    public class ClientData
    {
        public static Guid client1Id
        {
            get
            {
                return new Guid("ab0db2b1-2b62-4aef-8781-454fe93e7f85");
            }
        }

        public static Guid client2Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }

        public static Guid client3Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }

        public static Client clientEntity
        {
            get
            {
                return new Client() { Id = client3Id, ClientName = "Ministry of Petroluem Resources", Address = "plot 143 summer street kubwa abuja" };


            }
        }

        public static Client client
        {
            get
            {
                return new Client() { Id = client1Id, ClientName = "Ministry of Petroluem Resources", Address = "plot 143 summer street kubwa abuja" };


            }
        }
        public static List<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client { Id = client1Id, ClientName = "Ministry of Petroluem Resources", Address = "plot 143 summer street kubwa abuja" },
                    new Client { Id = client2Id, ClientName = "NNPC", Address = "Maitama abuja"}
                };
            }
        }


    }
}
