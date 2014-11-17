/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using System.Data;
using System.Data.Common;
using Starsoft.NetUniver.Core;
using Starsoft.NetUniver.Core.Query;
using SC.Data.SCWeb;

namespace  SC.Data.SqlClient.SCWeb
{
    /// <summary>
    /// 数据操作提供者
    /// </summary>
    public partial class SCWebDataProvider : DataProvider, ISCWebDataProvider
    {
        private static object syncRoot = new Object();

        #region ISCWebDataProvider 成员
        
		private IApplyHelper _applyHelper;
        /// <summary>
        /// 操作对象
        /// </summary>
        public IApplyHelper ApplyHelper
        {
            get
            {
                if (this._applyHelper == null)
                {
                    lock (syncRoot)
                    {
                        if (this._applyHelper == null)
                        {
                            this._applyHelper = new ApplyHelper(this);
                        }
                    }
                }

                return this._applyHelper;
            }
        }
		

        #endregion
    }
}