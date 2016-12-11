using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.Db.Mappings;

namespace ClientManagement.Core.Repositories.Db
{
    public class ClientManagementContext : DbContext
    {

        public ClientManagementContext()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }



        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new EmployeeMap());
        }
    }


}
