using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHost.Ioc
{
    public class IoCResolverFactory
    {
        static WindsorContainer _container = new WindsorContainer();
        static IoCResolverFactory()
        {
            _container.BeginScope();
            //_container.Register(Component.For<ICurrentRequestService>().Instance(currentRequestService).LifestyleScoped());
            _container.Register(Component.For<ICurrentRequestService>().ImplementedBy<CurrentRequestService>().LifestyleScoped());
        }

        public static WindsorContainer GetContainer()
        {
            return _container;
        }
    }

    public interface ICurrentRequestService
    {
        int MyProperty { get; set; }
    }

    public class CurrentRequestService : ICurrentRequestService,  IDisposable
    {
        public CurrentRequestService()
        {
            Console.WriteLine("CurrentRequestService ctor");
        }
        public int MyProperty { get ; set; }

        public void Dispose()
        {
            Console.WriteLine("CurrentRequestService disposed");
        }
    }
}
