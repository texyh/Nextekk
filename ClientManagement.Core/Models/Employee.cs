using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
        }
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public Gender Gender { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Project> Projects { get; set; }


    }
}
