using System.Collections.Generic;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    public interface IDatabase
    {
        Dictionary<string, string> GetTable();
    }
}