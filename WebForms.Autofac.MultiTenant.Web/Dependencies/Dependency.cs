using WebForms.Autofac.MultiTenant.Minimal.Models;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    /// <summary>
    /// Simple dependency implementation.
    /// </summary>
    public class Dependency : IDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency"/> class.
        /// </summary>
        public Dependency(Tenant tenant)
        {
            this.ConnectionString = tenant.Provider;
            this.TenantName = tenant.Name;
        }

        /// <summary>
        /// Gets the unique instance ID for the dependency.
        /// </summary>
        /// <value>
        /// A <see cref="System.Guid"/> that indicates the unique ID for the
        /// instance.
        /// </value>
        public string ConnectionString { get; private set; }

        public string TenantName { get; private set; }
    }
}