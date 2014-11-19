using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using System.Text;
using Sitecore.Links;
using SC.Logic;

namespace SC.WebSite.Layouts.Common
{
    public partial class UC_Head : SC.Logic.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetNav();
            Load_AreaList();
        }

        /// <summary>
        /// 加载区域列表
        /// </summary>
        private void Load_AreaList()
        {
            this.AreaItemList = Page.HomeItem.Axes.SelectItems("./*[@@templatename='Area']");
        }

        /// <summary>
        /// 获取当前Item的ChildItem
        /// </summary>
        /// <param name="currentItem"></param>
        /// <returns></returns>
        protected Sitecore.Data.Items.Item[] Get_AreaChildList(Sitecore.Data.Items.Item currentItem)
        {
            return currentItem.Axes.SelectItems("./*[@@templatename='Area']");
        }

        /// <summary>
        /// 获取导航数据
        /// </summary>
        private void GetNav()
        {

            Sitecore.Data.Items.Item AreaItem = Page.AreaItem;
            Sitecore.Data.Items.Item Home = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString());
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

        #region 属性
        protected Sitecore.Data.Items.Item[] AreaItemList
        {
            get;
            set;
        }
        #endregion
    }
}