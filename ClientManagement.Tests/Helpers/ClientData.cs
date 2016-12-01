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

        public static ClientEntity client
        {
            get
            {
                return new ClientEntity() { Id = client1Id, ClientName = "Ministry of Petroluem Resources", Address = "plot 143 summer street kubwa abuja" };


            }
        }


    }
}
