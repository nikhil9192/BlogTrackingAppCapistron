using System.Web.Mvc;
using BlogApp.Repositories;
using DataAccessLayer.Authentication;
using Unity;
using Unity.Mvc5;

namespace BlogUILayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IEmpInfoRepository, EmpInfoRepository>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IBlogInfoRepository, BlogInfoRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}