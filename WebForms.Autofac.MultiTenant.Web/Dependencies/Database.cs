using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    public class Database : IDatabase
    {
        private readonly TenantIdentificationStrategy _tenantIdStrategy;
        private readonly IConnectionStringProvider _connectionStringProvider;

        public Database(TenantIdentificationStrategy tenantIdStrategy, IConnectionStringProvider connectionStringProvider)
        {
            _tenantIdStrategy = tenantIdStrategy;
            _connectionStringProvider = connectionStringProvider;
        }

        public Dictionary<string, string> GetTable()
        {
            //for demo purposes, I will create a dictionary here.
            var data = new Dictionary<string, string>();
            data.Add(_tenantIdStrategy.CurrentTenant, _connectionStringProvider.ConnectionString());

            return data;
        }
    }
}
