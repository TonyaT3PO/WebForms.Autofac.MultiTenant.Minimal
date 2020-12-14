using Autofac.Integration.Web.Forms;
using Autofac.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Autofac.MultiTenant.Minimal.Dependencies;

namespace WebForms.Autofac.MultiTenant.Minimal.Controls
{
    
    public partial class TenantDetailControl : System.Web.UI.UserControl
    {
        public IDependency _dependency { get; set; }
        public IDependencyConsumer _consumer { get; set; }

        public ITenantIdentificationStrategy _tenantIdStrategy { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TenantNameLabel.Text = _tenantIdStrategy.
            ConnectionStringLabel.Text = _consumer.Dependency.GetType().Name;
        }
    }
}