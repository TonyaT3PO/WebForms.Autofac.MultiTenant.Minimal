using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly Tenants _tenants;
        private readonly TenantIdentificationStrategy _tenantIdStrategy;

       

        public ConnectionStringProvider(Tenants tenants, TenantIdentificationStrategy tenantIdStrategy)
        {
            _tenants = tenants;
            _tenantIdStrategy = tenantIdStrategy;

        }

        public string ConnectionString()
        {
            var currentTenant = _tenantIdStrategy.CurrentTenant;
            var tenant = _tenants.TenantList().Find(t => t.Name == currentTenant);
            return tenant.Provider;
        }

    }
}
