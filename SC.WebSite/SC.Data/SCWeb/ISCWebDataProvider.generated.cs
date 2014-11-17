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

namespace SC.Data.SCWeb
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ISCWebDataProvider : IDataProvider
    {
        /// <summary>
        /// 操作对象
        /// </summary>
        IApplyHelper ApplyHelper { get; }
		
    }
}