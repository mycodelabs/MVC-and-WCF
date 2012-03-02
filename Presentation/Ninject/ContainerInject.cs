using clienttasks;
using clienttasks.mappers;
using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
using Ninject.Modules;
using Presentation.contracts;

namespace Presentation
{
    public class ContainerInject : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMeetingTasks>().To<MeetingTasks>();
            Kernel.Bind<IMeetingsPageViewModelMapper>().To<MeetingsPageViewModelMapper>();
            Kernel.Bind<IMeetingsService>().To<MeetingsServiceClient>();
        }
    }
}