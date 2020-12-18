using Autofac.Multitenant;
using System.Linq;
using System.Web;

namespace WebForms.Autofac.MultiTenant.Minimal
{
    public class TenantIdentificationStrategy : ITenantIdentificationStrategy
    {
        public string CurrentTenant { get; set; }

        public bool TryIdentifyTenant(out object tenantId)
        {
            var context = HttpContext.Current;
            try
            {
                if (context == null || context.Request == null)
                {
                    tenantId = null;
                    return false;
                }
            }
            catch (HttpException)
            {
                // Happens at app startup in IIS 7.0
            }

            TenantName();
            
            tenantId = CurrentTenant;
            return tenantId != null;
        }

        public void TenantName()
        {
            string tenantName = "";

            string[] urlParts = null;
            HttpContext httpContext = HttpContext.Current;
            urlParts = httpContext.Request.Url.Segments.Select(x => x.TrimEnd('/')).Skip(1).ToArray();
            if(urlParts.Count() > 0)
            {
                tenantName = urlParts[0];

            }

            CurrentTenant = tenantName;
        }

    }

}
