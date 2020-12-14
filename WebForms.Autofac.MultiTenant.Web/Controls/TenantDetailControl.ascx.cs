using Autofac.Integration.Web.Forms;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            TenantNameLabel.Text = _dependency.TenantName;
            ConnectionStringLabel.Text = _dependency.ConnectionString;
        }
    }
}