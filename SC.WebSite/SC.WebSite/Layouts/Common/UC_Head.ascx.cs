using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using System.Text;
using Sitecore.Links;
using Sitecore.Data.Items;
namespace SC.WebSite.Layouts.Common
{
    public partial class UC_Head : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        private void SelectArea()
        {
            Item Home = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString());
            string url = Request.Url.ToString();
            Item ddd = Sitecore.Context.Item;
            if (Home != null)
            {
                StringBuilder builder = new StringBuilder();
                if (Home.Children.Count > 0)
                {
                    builder.Append("<ul>");
                    for (int i = 0; i < Home.Children.Count; i++)
                    {
                        if (Home.Children[i].Fields["IsOption"] != null)
                        {
                            builder.Append("");
                            if (Home.Children[i].Fields["IsOption"].Value == "1")
                            {
                                builder.Append("<li> <a href='" + LinkManager.GetItemUrl(Home.Children[i]) + "'>" + Home.Children[i].Name + "</li>");
                            }

                            else
                            {
                                builder.Append("<li>" + Home.Children[i].Name + "</li>");
                            }

                        }
                    }
                    builder.Append("</ul>");
                }
               // divNav.InnerHtml = builder.ToString();

            }
             
        }
        /// <summary>
        /// 获取导航数据
        /// </summary>
        private void GetNav()
        {
            
        }
    }
}