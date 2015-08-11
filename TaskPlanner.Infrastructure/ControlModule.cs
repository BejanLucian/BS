using Microsoft.Practices.Unity;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.Infrastructure
{
    public static class ControlModule
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWorkProvider, UnitOfWorkProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
        }


    }
}
