using System;
using contracts;
using infrasrtucture;
using infrasrtucture.contracts;
using Ninject.Modules;
using services.mappers;
using services.mappers.contracts;

namespace services 
{
    public class ContainerInject : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMeetingsService>().To<MeetingsService>();
            Kernel.Bind<IMeetingRepository>().To<MeetingRepository>();
            Kernel.Bind<IMeetingDataContractMapper>().To<MeetingDataContractMapper>();
            Kernel.Bind<IXmlGateway>().To<XmlGateway>();
            Kernel.Bind<IFileProvider>().To<FileProvider>();
            Kernel.Bind<IProviderFactory>().To<XmlProviderFactory>();
        }
    }
}