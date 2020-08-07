using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AutofacSampleApi.App_Start
{
    public static class AutofaConfiguration
    {

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterService(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static IContainer RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<LogingInterceptor>().AsSelf();

            //var _Controller = Assembly.Load("AutofacSampleApi");
            builder.RegisterApiControllers(Assembly.GetCallingAssembly())
                .AsSelf()
                .PropertiesAutowired();

            var IService = Assembly.Load("SampleInterface");
            var Service = Assembly.Load("SampleService");

            builder.RegisterAssemblyTypes(IService, Service)
                .Where(obj => obj.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .InterceptedBy(typeof(LogingInterceptor))
                .EnableInterfaceInterceptors();

            return builder.Build();
        }
    }
}