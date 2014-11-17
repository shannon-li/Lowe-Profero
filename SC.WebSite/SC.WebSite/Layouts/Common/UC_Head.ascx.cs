using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SC.WebSite.Layouts.Common
{
    public partial class UC_Head : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sitecore.Data.Items.Item item = Sitecore.Context.Item;
            if (item!=null)
            {
                for (int i = 0; i < item.Children.Count; i++)
                {
                    
                }
            }
        }
    }
}