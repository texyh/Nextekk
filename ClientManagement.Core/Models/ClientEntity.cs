using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Core.Models
{
    public class ClientEntity
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }

        public string Address { get; set; }
       
    }
}
