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
using Starsoft.NetUniver.Core.Business;
using SC.Business;
using SC.Business.SCWeb;

namespace SC.Data.SCWeb
{
    /// <summary>
    /// 表示操作助手
    /// </summary>
    partial interface IApplyHelper
    {
        #region 插入

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>如果插入成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Insert(Apply entity);

        /// <summary>
        /// 执行插入查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果插入成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Insert(ApplyQuery query);

        #endregion

        #region 更新

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>如果更新成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Update(Apply entity);

        /// <summary>
        /// 执行更新查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果更新成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Update(ApplyQuery query);

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除
        /// </summary>
		/// <param name="id"></param>
        /// <returns>如果删除成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Delete(int id);

        /// <summary>
        /// 执行删除查询
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>如果删除成功则返回<c>true</c>，否则返回<c>false</c></returns>
        bool Delete(ApplyQuery query);

        #endregion

        #region 根据索引或主键取得

        /// <summary>
        /// 根据主键取得
        /// </summary>
		/// <param name="id"></param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        Apply GetById(int id, params object[] queryItems);
		
        /// <summary>
        /// 根据主键取得
        /// </summary>
		/// <param name="id"></param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        Apply GetById(int id, bool convertBlankToNull, params object[] queryItems);

        /// <summary>
        /// 根据主键取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        T GetById<T>(int id, params object[] queryItems) where T : Entity, new();
		
        /// <summary>
        /// 根据主键取得
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
		/// <param name="id"></param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <param name="queryItems">选择列数组，其中每项可为Cast、QueryItem、QueryExpression、DynamicQuery、string类型对象，如果选择原生的不加任何字符的请用&lt;&gt;包含，比如&lt;Test&gt;</param>
        /// <returns></returns>
        T GetById<T>(int id, bool convertBlankToNull, params object[] queryItems) where T : Entity, new();

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">用户实体动态查询</param>
        /// <returns>用户实体集合</returns>
        TList<Apply> Query(ApplyQuery query);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询语句构造体</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>用户实体集合</returns>
        TList<Apply> Query(ApplyQuery query, bool convertBlankToNull);

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询语句构造体</param>
        /// <returns>用户实体集合</returns>
        TList<T> Query<T>(ApplyQuery query) where T : Entity, new();

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询语句构造体</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>用户实体集合</returns>
        TList<T> Query<T>(ApplyQuery query, bool convertBlankToNull) where T : Entity, new();

        #endregion
    }
}