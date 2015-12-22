using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using ServiceLayer;
namespace DependencyInjection.Services
{
    public class IocContainer
    {
        private static IContainer Container { get; set; }

        public static T GetServiceType<T>(){
            using (var scope = Container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }
        
        public static void RegisterService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ServiceLayer.UserService.UserService>().As<Abstraction.Services.IUserService>();
            builder.RegisterType<ServiceLayer.AccountService.AccountService>().As<Abstraction.Services.IAccountService>();
            Container = builder.Build();
        }
    }
}
