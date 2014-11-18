using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SC.Logic;

namespace SC.WebSite.Layouts.Work
{
    public partial class List : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_WorkList();
        }

        #region 方法
        /// <summary>
        /// 加载Work集合
        /// </summary>
        private void Load_WorkList()
        {
            Sitecore.Data.Items.Item currentItem = Sitecore.Context.Item;

            this.List_Works = Sitecore.Context.Item.Axes.SelectItems(".//*[@@templatename='WorkDetail']");
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
        /// 获取对包含服务器控件的 CommonPage 实例的引用
        /// </summary>
        public new LogicPage Page
        {
            get
            {
                LogicPage page = base.Page as LogicPage;
                if (page == null)
                {
                    throw new InvalidOperationException("A UserControl can be used only with content pages that derive from LP.CommonPage.CommonPage.");
                }
                return page;
            }
        }
        #endregion
    }
}