/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using Starsoft.NetUniver.Core.Business;

namespace SC.Business.SCWeb
{
    /// <summary>
    /// 表示实体
    /// </summary>
    public partial interface IApply
    {
        /// <summary>
        /// 
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string FileAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Introduction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Area { get; set; }

    }
}