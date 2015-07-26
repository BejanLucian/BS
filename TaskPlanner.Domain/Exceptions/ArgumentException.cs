using System;

namespace TaskPlanner.Domain.Exceptions
{
    public class ArgumentException<T,TResult> : DomainException
    {
        public ArgumentException(string argumentName)
            : base(ComposeErrorMessage(argumentName))
        {
        }

        private static string ComposeErrorMessage(string argumentName)
        {
            return string.Format("Argument is missing: {0}.", argumentName);
        }
    }
}
