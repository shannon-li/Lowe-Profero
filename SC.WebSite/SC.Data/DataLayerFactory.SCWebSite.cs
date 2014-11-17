/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using Starsoft.NetUniver.Core.Data;
using SC.Data.SCWeb;

namespace SC.Data
{
    /// <summary>
    /// 表示数据提供者工厂
    /// </summary>
    public partial class DataLayerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISCWebDataProvider SCWebDataProvider
        {
            get
            {
                return DataProviderFactory.Instance.GetInstance<ISCWebDataProvider>("SCWebDataProvider");
            }
        }
		
    }
}
