using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.DataAccess.Exceptions
{
    public class InvalidDataContextException : DataAccessException
    {
        public InvalidDataContextException(Type dataContextType)
            : base(ComposeErrorMessage(dataContextType))
        {
        }

        private static string ComposeErrorMessage(Type dataContextType)
        {
            return string.Format("Inavlid data context type <{0}>.", dataContextType);
        }
    }
}
