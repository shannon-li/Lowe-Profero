﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SC.Logic
{
    public class LogicPage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
          
        }

        /// <summary>
        /// 在未使用服务器FORM时,替代了ISPOSTBACK
        /// </summary>
        public virtual bool IsPost
        {
            get
            {
                return (base.Request.HttpMethod == "POST");
            }
        }


        #region SEO 属性
        /// <summary>
        /// 当前页面PageTitle
        /// </summary>
        public string PageTitle
        {
            get { return Sitecore.Context.Item["PageTitle"]; }
        }

        /// <summary>
        /// 当前页面PageKeywords
        /// </summary>
        public string PageKeywords
        {
            get { return string.Format("<meta name=\"keywords\" content=\"{0}\" />", Sitecore.Context.Item["Keywords"]); }
        }

        /// <summary>
        /// 当前页面PageDescription
        /// </summary>
        public string PageDescription
        {
            get { return string.Format("<meta name=\"description\" content=\"{0}\" />", Sitecore.Context.Item["Description"]); }
        }

        #endregion

        /// <summary>
        /// 当前站点HomeItem
        /// </summary>
        public Sitecore.Data.Items.Item HomeItem
        {
            get { return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString()); }
        }
    }
}
