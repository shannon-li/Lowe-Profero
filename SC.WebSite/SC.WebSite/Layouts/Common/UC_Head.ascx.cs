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
using SC.Logic;
namespace SC.WebSite.Layouts.Common
{
    public partial class UC_Head : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetNav();
        }

        private void SelectArea()
        {
            Item Home = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString());
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

            Item AreaItem =Page.AreaItem;
            Item Home = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString());
            StringBuilder builder = new StringBuilder();
            if (AreaItem != null || Home != null)
            {
                
                builder.Append("<ul>");
                for (int i = 0; i < AreaItem.Children.Count; i++)
                {
                    builder.Append("<li> <a href='" + LinkManager.GetItemUrl(AreaItem.Children[i]) + "'>" + AreaItem.Children[i].Name + "</li>");
                }
                for (int i = 0; i < Home.Children.Count; i++)
                {
                    if (Home.Children[i].Fields["IsShow"] != null)
                    {
                        if (Home.Children[i].Fields["IsShow"].Value == "1")
                        {
                            builder.Append("<li> <a href='" + LinkManager.GetItemUrl(Home.Children[i]) + "'>" + Home.Children[i].Name + "</li>");
                        }

                    }
                }
                builder.Append("</ul>");
            }
            literNAV.Text = builder.ToString();
        }
        /// <summary>
        /// 获取对包含服务器控件的 LogicPage 实例的引用
        /// </summary>
        public new LogicPage Page
        {
            get
            {
                LogicPage page = base.Page as LogicPage;
                if (page == null)
                {
                    throw new InvalidOperationException("A UserControl can be used only with content pages that derive from SC.Logic.LogicPage");
                }
                return page;
            }
        }
    }
}