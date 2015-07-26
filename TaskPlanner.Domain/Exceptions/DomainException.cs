using System;
using System.Diagnostics;

namespace TaskPlanner.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string reason)
            : base(ComposeErrorMessage(reason))
        {
        }

        private static string ComposeErrorMessage(string errorReason)
        {
            string source = "?";
            var sourceObjectType = new StackFrame(1).GetMethod().DeclaringType;
            if (sourceObjectType != null)
            {
                source = sourceObjectType.ToString();
            }

            return string.Format("[{0}]: {1}", source, errorReason);
        }
    }
}
