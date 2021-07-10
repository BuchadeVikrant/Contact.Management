using Contacts.Management.DataAccess.Repositories;
using Contacts.Management.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Contacts.Management
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContact, ContactsRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}