using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Core.Models
{
    public class Project
    {
        public Project()
        {
            Employees = new List<Employee>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        public ProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string ClientName { get; set; }
        public Guid  ClientId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }



    }


}
