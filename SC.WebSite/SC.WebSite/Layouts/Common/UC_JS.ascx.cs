using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC.WebSite.Layouts.Common
{
    public partial class UC_JS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Attributes();
        }

        private void Load_Attributes()
        {
            string parameters = Attributes["sc_parameters"];
            if (!string.IsNullOrEmpty(parameters))
            {
                string[] paramList = parameters.Split('&');
                foreach (string param in paramList)
                {
                    Literal_Page_JS.Text += string.Format("<script src=\"{0}\"></script>\n", HttpUtility.UrlDecode(param.Split('=')[1]));
                }
            }
        }
    }
}