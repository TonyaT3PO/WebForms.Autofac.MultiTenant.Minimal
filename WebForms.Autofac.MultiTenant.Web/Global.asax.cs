using Autofac;
using Autofac.Integration.Web;
using Autofac.Multitenant;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebForms.Autofac.MultiTenant.Minimal;
using WebForms.Autofac.MultiTenant.Minimal.Dependencies;

namespace WebForms.Autofac.MultiTenant.Minimal
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        private static IContainerProvider _containerProvider;
        private static TenantIdentificationStrategy _tenantIdStrategy;

        public IContainerProvider ContainerProvider => _containerProvider;

        private void Application_Start(object sender, EventArgs e)
        {
            MultiTenantContainerConfig();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void MultiTenantContainerConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Consumer>().As<IDependencyConsumer>().InstancePerDependency();
            builder.RegisterType<BaseDependency>().As<IDependency>().SingleInstance();

            _tenantIdStrategy = new TenantIdentificationStrategy();

            //builder.RegisterType<Tenants>()
            //    .AsSelf()
            //    .SingleInstance();

            var tenants = new Tenants();
            var tenantList = tenants.TenantList();

            builder.RegisterInstance(_tenantIdStrategy).As<ITenantIdentificationStrategy>();

            
            var multitenantContainer = new MultitenantContainer(_tenantIdStrategy, builder.Build());

            multitenantContainer.ConfigureTenant('1', b => b.RegisterType<Tenant1Dependency>().As<IDependency>().InstancePerDependency());


            multitenantContainer.ConfigureTenant('2', b => b.RegisterType<Tenant2Dependency>().As<IDependency>().SingleInstance());


            //foreach (var tenant in tenantList)
            //{

            //    multitenantContainer.ConfigureTenant(tenant.Name, b =>
            //    {


            //        //b.Register(d => new Dependency(tenant))
            //        //    .As<IDependency>()
            //        //    .InstancePerDependency();

            //        //b.Register(appContext => new AppDbContext(connectionString))
            //        //    .InstancePerTenant()
            //        //    .AsSelf();

            //        //b.RegisterType<CourseRepository>()
            //        //    .As<ICourseRepository>();
            //    });
            //}

            _containerProvider = new ContainerProvider(multitenantContainer);
        }
    }
}