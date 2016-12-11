using ClientManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Core.Repositories.Db.Mappings
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(t => t.Id);
            ToTable("Employees");

            HasMany(t => t.Projects)
                .WithMany(t => t.Employees)
                .Map(t =>
               {
                   t.ToTable("EmployeeProjects");
                   t.MapLeftKey("EmployeeId");
                   t.MapRightKey("ProjectId");
               });
        }
    }
}
