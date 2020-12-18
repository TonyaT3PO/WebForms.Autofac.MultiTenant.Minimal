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
        public IDependency Dependency { get; set; }

        //public IDatabase Database { get; set; }

        //public IConnectionStringProvider ConnectionStringProvider { get; set; }
        //public TenantIdentificationStrategy _tenantIdStrategy { get; set; }
        //public Tenants _tenants { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var records = Dependency.GetData();
            GridView1.DataSource = records;
            GridView1.DataBind();
            //TenantNameLabel.Text = _tenantIdStrategy.CurrentTenant;
            //ConnectionStringLabel.Text = ConnectionStringProvider.ConnectionString();
        }
    }
}