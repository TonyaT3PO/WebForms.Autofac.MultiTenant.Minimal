using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForms.Autofac.MultiTenant.Minimal.Models;

namespace WebForms.Autofac.MultiTenant.Minimal
{
    public class Tenants
    {
        public List<Tenant> TenantList()
        {
            var tenants = new List<Tenant>();
            tenants.Add(new Tenant { Id = 1, Name = "Tenant1", ClientUrl = "Tenant1", Provider = "ConnectionString for Tenant1" });
            tenants.Add(new Tenant { Id = 2, Name = "Tenant2", ClientUrl = "Tenant2", Provider = "ConnectionString for Tenant2" });
            return tenants;
        }
    }
}