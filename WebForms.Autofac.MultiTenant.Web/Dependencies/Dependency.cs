using System.Collections.Generic;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{

    public class Dependency : IDependency
    {
        private readonly TenantIdentificationStrategy _tenantIdStrategy;
        private readonly IDatabase _database;

        public Dependency(TenantIdentificationStrategy tenantIdStrategy, IDatabase database)
        {
            _database = database;
            _tenantIdStrategy = tenantIdStrategy;
        }

        public Dictionary<string, string> GetData()
        {
            return _database.GetTable();
        }
    }
}