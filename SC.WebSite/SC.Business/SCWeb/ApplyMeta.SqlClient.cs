/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using Starsoft.NetUniver.Core;

namespace SC.Business.SCWeb
{
    /// <summary>
    /// 表示元数据
    /// </summary>
    public partial class ApplyMeta
    {
        /// <summary>
        /// 获取提供者特别元素据
        /// </summary>
        /// <returns></returns>
        private ProviderSpecificMetadata GetSqlClientMetadata()
        {
            ProviderSpecificMetadata meta = new ProviderSpecificMetadata();

            meta.AddTypeMap("Id", new TypeMap("int", "System.Int32"));
            meta.AddTypeMap("Name", new TypeMap("varchar", "System.String"));
            meta.AddTypeMap("Role", new TypeMap("varchar", "System.String"));
            meta.AddTypeMap("Email", new TypeMap("varchar", "System.String"));
            meta.AddTypeMap("FileAddress", new TypeMap("varchar", "System.String"));
            meta.AddTypeMap("Introduction", new TypeMap("text", "System.String"));
            meta.AddTypeMap("Area", new TypeMap("nvarchar", "System.String"));
            meta.Source = "Apply";
            meta.Destination = "Apply";

            return meta;
        }
    }
}