using System;
using System.Web;
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

        #region Item
        /// <summary>
        /// 当前站点HomeItem
        /// </summary>
        public Sitecore.Data.Items.Item HomeItem
        {
            get { return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString()); }
        }

        private Sitecore.Data.Items.Item _startItem;
        /// <summary>
        /// 当前站点AreaItem
        /// </summary>
        public Sitecore.Data.Items.Item AreaItem
        {
            get
            {
                if (_startItem == null)
                {
                    string area = "global";
                    var splits = HttpContext.Current.Request.Url.Host.Split('.');
                    if (splits.Length > 0)
                    {
                        switch (splits[0].ToLower())
                        {
                            case "global":
                            case "london":
                            case "beijing": area = splits[0]; break;
                        }
                    }

                    Sitecore.Sites.Site currentSite = Sitecore.Sites.SiteManager.GetSite(area);
                    if (currentSite != null)
                    {
                        Sitecore.Data.Items.Item startItem = Sitecore.Context.Database.GetItem(currentSite.Properties["rootPath"] + currentSite.Properties["startItem"]);

                        if (startItem != null)
                        {
                            this._startItem = startItem;
                            return this._startItem;
                        }
                        else
                        {
                            return this.HomeItem;
                        }
                    }
                    else
                    {
                        return this.HomeItem;
                    }
                }
                else return this._startItem;
            }
        }
        #endregion
    }
}
