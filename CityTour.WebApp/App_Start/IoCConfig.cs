using Autofac;
using Autofac.Integration.Mvc;
using CityTour.Domain.Services;
using CityTour.Persistence;
using CityTour.Persistence.Core;
using System.Reflection;
using System.Web.Mvc;

namespace CityTour.WebApp.App_Start
{
    public class IoCConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            Register(builder);

            IContainer container = builder.Build();

            DependencyResolver.SetResolver
                (new AutofacDependencyResolver(container));
        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new AutoMapperModule(Assembly.GetExecutingAssembly()));

            builder.Register(z => new CityTourContext())
                .InstancePerRequest();

            builder.RegisterType<CityTourUnitOfWork>()
                .As<IEFUnitOfWork>()
                .As<IUnitOfWork>() 
                .InstancePerRequest();
         
            builder.RegisterGeneric(typeof(EFRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();

            builder.RegisterType<GuestService>()
                .As<IGuestService>()                
                .InstancePerRequest();

            builder.RegisterType<GuestItineararyRequestService>()
                .As<IGuestItineararyRequestService>()
                .InstancePerRequest();

            builder.RegisterType<ItineararyService>()
                .As<IItineararyService>()
                .InstancePerRequest();
        }
    }
}