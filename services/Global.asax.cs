using System;
using contracts;
using infrasrtucture;
using Ninject;
using Ninject.Extensions.Wcf;

namespace services 
{
    public class Global : NinjectWcfApplication  
    {
        private IKernel ContainerRegistration()
        {
            IKernel kernel = new StandardKernel(new ContainerInject());
            return kernel;
        }
        protected override IKernel CreateKernel()
        {
            return ContainerRegistration();
        }
    }
}