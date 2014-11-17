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
using System.Data.SqlClient;
using Starsoft.NetUniver.Core;
using Starsoft.NetUniver.Core.Query;
using Starsoft.NetUniver.Core.Business;
using SC.Business.SCWeb;
using SC.Data.SCWeb;

namespace SC.Data.SqlClient.SCWeb
{
    /// <summary>
    /// 表示操作助手
    /// </summary>
    public partial class ApplyHelper : IApplyHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataProvider">数据操作提供者</param>
        public ApplyHelper(SCWebDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        #region 插入

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>如果插入成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Insert(Apply entity)
        {
			int total = 0;
			ApplyQuery query = new ApplyQuery();
			foreach (PropertySetting propertySetting in entity.PropertySettings)
			{
                ColumnMetadata columnMetadata = entity.SchemaMeta.Columns[propertySetting.FieldName];
                if (columnMetadata != null)
                {
                    QueryItem queryItem = new QueryItem(query, propertySetting.FieldName, columnMetadata.Type);
                    if (!columnMetadata.IsIdentity)
                    {
                        query.Insert(queryItem.Value(propertySetting.FieldValue));

                        total++;
                    }
                 }
             }

            if (total == 0)
            {
                return false;
            }
			
            int results = this.DataProvider.ExecuteInsertQuery(query);

            return Convert.ToBoolean(results);
        }

        /// <summary>
        /// 执行插入查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果插入成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Insert(ApplyQuery query)
        {
            int results = this.DataProvider.ExecuteInsertQuery(query);

            return Convert.ToBoolean(results);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>如果更新成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Update(Apply entity)
        {
            if (entity.ChangedFieldNames.Count == 0)
            {
                return false;
            }

            ApplyQuery query = new ApplyQuery();

            foreach (string fieldName in entity.ChangedFieldNames)
            {
                ColumnMetadata columnMetadata = entity.SchemaMeta.Columns[fieldName];
                if ((columnMetadata != null) && (!columnMetadata.IsIdentity) && (!columnMetadata.IsInPrimaryKey))
                {
                    QueryItem queryItem = new QueryItem(query, fieldName, columnMetadata.Type);
                    query.Update(queryItem.Set(entity.GetObjectValue(fieldName)));
                }
            }

            query.Where(query.Id == entity.Id);

            int results = this.DataProvider.ExecuteUpdateQuery(query);
            entity.AcceptChanges();

            return Convert.ToBoolean(results);
        }

        /// <summary>
        /// 执行更新查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果更新成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Update(ApplyQuery query)
        {
            int results = this.DataProvider.ExecuteUpdateQuery(query);

            return Convert.ToBoolean(results);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除
        /// </summary>
		/// <param name="id"></param>
        /// <returns>如果删除成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Delete(int id)
        {
            ApplyQuery query = new ApplyQuery();
            query.Where(query.Id == id);
            int results = this.DataProvider.ExecuteDeleteQuery(query);

            return Convert.ToBoolean(results);
        }

        /// <summary>
        /// 执行删除查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果删除成功则返回<c>true</c>，否则返回<c>false</c></returns>
        public bool Delete(ApplyQuery query)
        {
            int results = this.DataProvider.ExecuteDeleteQuery(query);

            return Convert.ToBoolean(results);
        }

        #endregion
		
        #region 根据索引或主键取得

        /// <summary>
        /// 根据主键取得
        /// </summary>
		/// <param name="id"></param>
        /// <param name="queryItem">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        public Apply GetById(int id, params object[] queryItems)
        {
            return this.GetById(id, false, queryItems);
        }
		
        /// <summary>
        /// 根据主键取得
        /// </summary>
		/// <param name="id"></param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        public Apply GetById(int id, bool convertBlankToNull, params object[] queryItems)
        {
            return this.GetById<Apply>(id, convertBlankToNull, queryItems);
        }

        /// <summary>
        /// 根据主键取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        public T GetById<T>(int id, params object[] queryItems) where T : Entity, new()
        {
            return this.GetById<T>(id, false, queryItems);
        }
		
        /// <summary>
        /// 根据主键取得
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
		/// <param name="id"></param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        public T GetById<T>(int id, bool convertBlankToNull, params object[] queryItems) where T : Entity, new()
        {
            ApplyQuery query = new ApplyQuery();
            if (queryItems != null && queryItems.Length > 0)
            {
                query.Select(queryItems);
            }
            else
            {
                query.SelectAll();
            }
			query.Where(query.Id == id);
			
            return this.DataProvider.SingleQuery<T>(query);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">用户实体动态查询</param>
        /// <returns>用户实体集合</returns>
        public TList<Apply> Query(ApplyQuery query)
        {
            return this.Query<Apply>(query);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询语句构造体</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>用户实体集合</returns>
        public TList<Apply> Query(ApplyQuery query, bool convertBlankToNull)
        {
            return this.Query<Apply>(query, convertBlankToNull);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询语句构造体</param>
        /// <returns>用户实体集合</returns>
        public TList<T> Query<T>(ApplyQuery query) where T : Entity, new()
        {
            return this.Query<T>(query, false);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询语句构造体</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>用户实体集合</returns>
        public TList<T> Query<T>(ApplyQuery query, bool convertBlankToNull) where T : Entity, new()
        {
            return this.DataProvider.Query<T>(query, convertBlankToNull);
        }

        #endregion

        #region 属性成员

        private SCWebDataProvider _dataProvider;
        /// <summary>
        /// 数据提供者
        /// </summary>
        public SCWebDataProvider DataProvider
        {
            get { return this._dataProvider; }
        }

        #endregion
    }
}