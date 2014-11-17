/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Data;
using Starsoft.NetUniver.Core;

namespace SC.Business.SCWeb
{
   /// <summary>
    /// 表示元数据
    /// </summary>
    public partial class ApplyMeta : IMetadata
    {
        private static ApplyMeta m_instance;

        private ColumnMetadataCollection _columns;
		private Dictionary<string, ProviderSpecificMetadata> _providerMetadataMaps;

        /// <summary>
        /// 取得元数据唯一对象实例
        /// </summary>
        public static ApplyMeta Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new ApplyMeta();
                }

                return m_instance;
            }
        }

        /// <summary>
        /// 构造实体元数据实例对象
        /// </summary>
        private ApplyMeta()
        {
            this._columns = new ColumnMetadataCollection();
            ColumnMetadata c;

            c = new ColumnMetadata(ColumnNames.Id, PropertyNames.Id, typeof(int), DbType.Int32, true, false, false, 4);
            c.NumericPrecision =  10;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 1;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.Name, PropertyNames.Name, typeof(string), DbType.String, false, false, false, 50);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 2;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.Role, PropertyNames.Role, typeof(string), DbType.String, false, false, false, 50);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 3;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.Email, PropertyNames.Email, typeof(string), DbType.String, false, false, false, 50);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 4;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.FileAddress, PropertyNames.FileAddress, typeof(string), DbType.String, false, false, false, 50);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 5;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.Introduction, PropertyNames.Introduction, typeof(string), DbType.String, false, false, true, 2147483647);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 6;
			this._columns.Add(c);

            c = new ColumnMetadata(ColumnNames.Area, PropertyNames.Area, typeof(string), DbType.String, false, false, false, 20);
            c.NumericPrecision =  -1;
            c.NumericScale = 0;
            c.Description = "";
            c.HasDefault = false;
            c.IsComputed = false;
            c.IsReadOnly = false;
            c.Ordinal = 7;
			this._columns.Add(c);
            this._providerMetadataMaps = new Dictionary<string, ProviderSpecificMetadata>();
        }
		
        /// <summary>
        /// 取得提供者特别元数据
        /// </summary>
        /// <param name="providerName">元数据Guid</param>
        /// <returns>提供者特别元数据</returns>
        public ProviderSpecificMetadata GetProviderMetadata(string providerName)
        {
            if (!this._providerMetadataMaps.ContainsKey(providerName))
            {
                string method = string.Format("Get{0}Metadata", providerName);

                MapToProviderMetaDelegate mapMethod = (MapToProviderMetaDelegate)Delegate.CreateDelegate(typeof(MapToProviderMetaDelegate), this, method);
                if (mapMethod != null)
                {
                    this._providerMetadataMaps[providerName] = mapMethod();
                }
                else
                {
                    throw new Exception(string.Format("MapToMeta is not defined with the {0} Metadata", providerName));
                }
            }

            return this._providerMetadataMaps[providerName];
        }

        #region 列名

        /// <summary>
        /// 获取字段名常量类
        /// </summary>
        public class ColumnNames
        {
            /// <summary>
            /// 
            /// </summary>
            public const string Id = "Id";
			
            /// <summary>
            /// 
            /// </summary>
            public const string Name = "Name";
			
            /// <summary>
            /// 
            /// </summary>
            public const string Role = "Role";
			
            /// <summary>
            /// 
            /// </summary>
            public const string Email = "Email";
			
            /// <summary>
            /// 
            /// </summary>
            public const string FileAddress = "FileAddress";
			
            /// <summary>
            /// 
            /// </summary>
            public const string Introduction = "Introduction";
			
            /// <summary>
            /// 
            /// </summary>
            public const string Area = "Area";
			
        }

        #endregion

        #region 字段属性名

        /// <summary>
        /// 获取属性名常量类
        /// </summary>
        public class PropertyNames
        {
            /// <summary>
            /// 
            /// </summary>
            public const string Id = "Id";

            /// <summary>
            /// 
            /// </summary>
            public const string Name = "Name";

            /// <summary>
            /// 
            /// </summary>
            public const string Role = "Role";

            /// <summary>
            /// 
            /// </summary>
            public const string Email = "Email";

            /// <summary>
            /// 
            /// </summary>
            public const string FileAddress = "FileAddress";

            /// <summary>
            /// 
            /// </summary>
            public const string Introduction = "Introduction";

            /// <summary>
            /// 
            /// </summary>
            public const string Area = "Area";

        }

        #endregion	

        /// <summary>
        /// 元数据唯一的数据Guid
        /// </summary>
        public Guid DataId
        {
            get { return ApplyMeta.Guid; }
        }

        /// <summary>
        /// 列元数据集合
        /// </summary>
        public ColumnMetadataCollection Columns
        {
            get { return this._columns; }
        }
    }
}
