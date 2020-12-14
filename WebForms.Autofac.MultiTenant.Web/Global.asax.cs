using Autofac;
using Autofac.Integration.Web;
using Autofac.Multitenant;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebForms.Autofac.MultiTenant.Minimal;
using WebForms.Autofac.MultiTenant.Minimal.Dependencies;

namespace WebForms.AutoFac.MultiTenant.Minimal
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

            //builder.RegisterType<Tenants>()
            //    .AsSelf()
            //    .SingleInstance();

            var tenants = new Tenants();
            var tenantList = tenants.TenantList();

            builder.RegisterInstance(tenantIdStrategy).As<ITenantIdentificationStrategy>();
            var multitenantContainer = new MultitenantContainer(tenantIdStrategy, builder.Build());

            foreach (var tenant in tenantList)
            {
                multitenantContainer.ConfigureTenant(tenant.Name, b =>
                {
                    b.Register(d => new Dependency(tenant))
                        .As<IDependency>();

                    //b.Register(appContext => new AppDbContext(connectionString))
                    //    .InstancePerTenant()
                    //    .AsSelf();

                    //b.RegisterType<CourseRepository>()
                    //    .As<ICourseRepository>();
                });
            }

            _containerProvider = new ContainerProvider(multitenantContainer);
        }
    }
}