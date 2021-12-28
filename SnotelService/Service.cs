using LightInject;
using SnotelService.Interfaces;

namespace SnotelService
{
    public static class Service
    {
        static Service()
        {
            var container = new ServiceContainer();
            Bootstrapping.LightInject.Register(container);
            Client = container.GetInstance<ISnotelWebClient>();
        }

        public static ISnotelWebClient Client { get; }
    }
}
