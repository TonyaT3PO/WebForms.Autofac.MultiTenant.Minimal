using WebForms.Autofac.MultiTenant.Minimal.Models;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    /// <summary>
    /// Simple dependency implementation.
    /// </summary>
    public class Dependency : IDependency
    {
        public Dependency(Tenant tenant)
        {
            this.ConnectionString = tenant.Provider;
            this.TenantName = tenant.Name;
        }

      
        public string ConnectionString { get; private set; }

        public string TenantName { get; private set; }
    }
}