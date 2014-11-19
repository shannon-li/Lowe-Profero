using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC.Logic;

namespace SC.WebSite.Layouts.Work
{
    public partial class List : SC.Logic.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_WorkList();
            Load_ClientList();
        }

        #region 方法
        /// <summary>
        /// 加载Work集合
        /// </summary>
        private void Load_WorkList()
        {
            this.List_Works = Sitecore.Context.Item.Axes.SelectItems(string.Format(".//*[@@templatename='WorkDetail' and contains(@SelectArea, '{0}')]", Page.AreaItem.ID));

            this.Repeater_WorkList.DataSource = this.List_Works;
            this.Repeater_WorkList.DataBind();
        }

        /// <summary>
        /// 加载Client集合
        /// </summary>
        private void Load_ClientList()
        {
            this.List_Client = Sitecore.Data.Query.Query.SelectItems(string.Format("/sitecore/Content/Home/Client//*[@@templatename='ClientDetail' and contains(@SelectArea, '{0}')]", Page.AreaItem.ID));

            this.Repeater_ClientList.DataSource = this.List_Client;
            this.Repeater_ClientList.DataBind();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 当前地区Work集合
        /// </summary>
        protected Sitecore.Data.Items.Item[] List_Works
        {
            get;
            set;
        }
        /// <summary>
        /// 当前地区Client集合
        /// </summary>
        protected Sitecore.Data.Items.Item[] List_Client
        {
            get;
            set;
        }
        #endregion
    }
}