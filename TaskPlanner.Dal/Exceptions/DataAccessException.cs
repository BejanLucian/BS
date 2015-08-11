using System;
using System.Diagnostics;

namespace TaskPlanner.DataAccess.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string reason)
            : base(reason)
        {
        }
    }
}
