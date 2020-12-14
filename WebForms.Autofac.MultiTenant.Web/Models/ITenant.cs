namespace WebForms.Autofac.MultiTenant.Minimal.Models
{
    public interface ITenant
    {
        string ClientUrl { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Provider { get; set; }
    }
}