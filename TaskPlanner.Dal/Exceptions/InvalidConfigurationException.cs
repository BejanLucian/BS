using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.DataAccess.Exceptions
{
    public class InvalidConfigurationException : DataAccessException
    {
        public InvalidConfigurationException(string reason) : base(reason)
        {
        }
    }
}
