using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqMeUp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ElephantDataContext dbContext = new ElephantDataContext();
            GridView1.DataSource = from c in dbContext.theStats where c.countrycode.Contains("JP") select c;
            GridView1.DataBind();
        }
    }
}