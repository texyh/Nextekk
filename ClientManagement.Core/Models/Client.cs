using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Core.Models
{
    public class Client
    {
        public Client()
        {
            Projects = new List<Project>();
        }
        public Guid Id { get; set; }
        [Required]
        public string  Name{get;set;}
        [Required]
        public string Address { get; set; }
        public virtual ICollection<Project> Projects { get; set; }


    }

    
}
