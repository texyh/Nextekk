using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Core.Models
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
