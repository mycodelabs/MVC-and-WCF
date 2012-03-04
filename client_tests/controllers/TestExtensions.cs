using System;
using System.Web.Mvc;
using developwithpassion.specifications.extensions;
using Machine.Specifications;

namespace client_tests.controllers
{
    public static class TestExtensions
    {
        public static ViewResult ShouldBeAView(this ActionResult actionResult)
        {
             actionResult.downcast_to<ViewResult>().ViewName.ShouldBeEmpty();
            return actionResult.downcast_to<ViewResult>();
        }

        public static ViewResult And(this ViewResult viewResult)
        {
            return viewResult;
        }

        public static T ShouldContainAViewModelOfType<T>(this ViewResult viewResult)
        {
            viewResult.Model.ShouldBeOfType<T>();
            return (T)viewResult.Model;
        }
    }
}