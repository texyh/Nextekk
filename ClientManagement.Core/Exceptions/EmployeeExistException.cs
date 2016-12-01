using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Core.Exceptions
{
    public class EmployeeExistException:Exception
    {
        public EmployeeExistException()
            :base("Employee Already Assigned To Project")
        {

        }

        public EmployeeExistException(string message)
            :base(message)
        {
        }
    }
}
