using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClientManagement.Core.Models;
namespace ClientManagement.Core.Repositories.Db
{
    class ClientManagementContext:DbContext
    {
        
        public ClientManagementContext()
            :base("name=DefaultConnection")
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
