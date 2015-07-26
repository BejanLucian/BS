using Microsoft.Practices.Unity;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.Infrastructure
{
    public static class ControlModule
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUnitOfWorkProvider, UnitOfWorkProvider>();
        }
    }
}
