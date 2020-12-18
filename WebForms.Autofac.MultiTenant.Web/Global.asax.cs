using Autofac;
using Autofac.Integration.Web;
using Autofac.Multitenant;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebForms.Autofac.MultiTenant.Minimal.Dependencies;

namespace WebForms.Autofac.MultiTenant.Minimal
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        private static IContainerProvider _containerProvider;
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

            var tenantIdStrategy = new TenantIdentificationStrategy();

            var tenants = new Tenants();
            var tenantList = tenants.TenantList();

            builder.RegisterType<Tenants>().AsSelf().SingleInstance();
            builder.RegisterInstance(tenantIdStrategy).As<TenantIdentificationStrategy>();

            builder.RegisterType<Dependency>().As<IDependency>().InstancePerRequest();
            builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>().InstancePerRequest();
            builder.RegisterType<Database>().As<IDatabase>().InstancePerRequest();

            var multitenantContainer = new MultitenantContainer(tenantIdStrategy, builder.Build());

            _containerProvider = new ContainerProvider(multitenantContainer);
        }
    }
}