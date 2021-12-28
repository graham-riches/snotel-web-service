using LightInject;

namespace SnotelService.Bootstrapping
{
    internal class LightInject
    { 
        internal static void Register(ServiceContainer container)
        {
            container.RegisterAssembly(typeof(IocRegistration).Assembly);
        }
    }
}
