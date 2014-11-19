using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Logic
{
    public class UserControl : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {

        }

        #region 属性
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
                    throw new InvalidOperationException("A UserControl can be used only with content pages that derive from SC.Logic.LogicPage.");
                }
                return page;
            }
        }
        #endregion
    }
}
