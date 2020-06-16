using MediaLibrary.Common;
using MediaLibrary.DAL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MediaLibrary.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepo, MediaRepo>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}