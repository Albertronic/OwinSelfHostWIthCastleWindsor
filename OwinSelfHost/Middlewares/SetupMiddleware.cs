using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Microsoft.Owin;
using OwinSelfHost.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHost.Middlewares
{
    public class SetupMiddleware : OwinMiddleware
    {

        public SetupMiddleware(OwinMiddleware next) : base(next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
        }


        public override async Task Invoke(IOwinContext context)
        {
            IDisposable scope = null;
            try
            {
                //here I am starting new scope
                var container = IoCResolverFactory.GetContainer(); 
                scope = container.BeginScope();

                await Next.Invoke(context);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                //here I am disposing it
                scope?.Dispose();
            }
        }
    }
}
