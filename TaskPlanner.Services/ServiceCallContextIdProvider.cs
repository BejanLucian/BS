using System.Web;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.Services
{
    internal class ServiceCallContextIdProvider : IWorkflowContextIdProvider
    {
        public int GetWorflowAttachedContextIdentifier()
        {
            return HttpContext.Current.GetHashCode();
        }
    }
}
