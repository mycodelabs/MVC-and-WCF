using controllers.Home;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Presentation.contracts;

namespace client_tests.controllers
{
    [Subject("Home Controller specs")]
    public class home_controller_specs
    {
        public abstract class home_controller_concern : Observes<HomeController>
        {
            private Establish c = () =>
                                      {
                                          the_client_tasks = depends.on<IMeetingTasks>();
                                      };

            private static IMeetingTasks the_client_tasks;
        }
    }
}
