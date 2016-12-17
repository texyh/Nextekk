using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public string Name
        {
            get
            {
                return Lastname + " " + Firstname;
            }
        }


    }
}
