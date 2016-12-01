using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Core.Exceptions
{
    public class ProjectExistException:Exception
    {
        public ProjectExistException()
            :base("Project Already Assigned To Employee")
        {

        }

        public ProjectExistException(string message)
            :base(message)
        {
        }
    }
}
