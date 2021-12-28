using LightInject;
using SnotelService.Interfaces;
using SnotelService.Implementations;

namespace SnotelService
{
    public class IocRegistration : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterSingleton<ISnotelWebClient, SnotelWebClient>();
        }
    }
}
