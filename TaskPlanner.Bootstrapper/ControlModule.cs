using Microsoft.Practices.Unity;

namespace TaskPlanner.Bootstrapper
{
    public static class ControlModule
    {
        public static void BootsrapAll(UnityContainer container)
        {
            Bootstrapper.Initialise();

            Infrastructure.ControlModule.Register(container);
            Services.ControlModule.Register(container);
            Domain.ControlModule.Register(container);
            DataAccess.ControlModule.Register(container);
        }
    }
}
