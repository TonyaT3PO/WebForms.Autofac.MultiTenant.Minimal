namespace WebForms.Autofac.MultiTenant.Minimal.Models
{

    public class Tenant : ITenant
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ClientUrl { get; set; }

        public string Provider { get; set; }


    }
}
