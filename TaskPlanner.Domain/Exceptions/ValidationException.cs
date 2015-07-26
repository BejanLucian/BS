namespace TaskPlanner.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public ValidationException(string reason) : base(reason)
        {
        }
    }
}
