using System;
using System.Web.Mvc;
using developwithpassion.specifications.extensions;

namespace client_tests.controllers
{
    public static class TestExtensions
    {
        public static ViewResult ShouldBeAView(this ActionResult actionResult)
        {
            return actionResult.downcast_to<ViewResult>();
        }

        public static object And(this ViewResult viewResult)
        {
            return viewResult.Model;
        }

        public static bool ShouldContainAViewModelOfType(this object objType, Type targetType)
        {
            return ReferenceEquals(objType, targetType);
        }
    }
}