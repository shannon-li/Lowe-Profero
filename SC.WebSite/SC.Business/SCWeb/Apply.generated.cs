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
using Starsoft.NetUniver.Core;
using Starsoft.NetUniver.Core.Business;
using Starsoft.NetUniver.Core.Query;

namespace SC.Business.SCWeb
{
    #region 实体类
    
    /// <summary>
    /// 表示实体
    /// </summary>
    public partial class Apply : Entity, IApply
    {
       	#region 构造函数

        /// <summary>
        /// 构造实体实例对象
        /// </summary>
        public Apply()
        {
        }

        /// <summary>
        /// 构造实体实例对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public Apply(Entity entity)
            : base(entity)
        {
        }

        /// <summary>
        /// 构造实体实例对象
        /// </summary>
        /// <param name="convertBlankToNull">当获取属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        public Apply(bool convertBlankToNull)
            : base(convertBlankToNull)
        {

        }

        ///<summary>
        /// 构造函数
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        ///<param name="role"></param>
        ///<param name="email"></param>
        ///<param name="fileAddress"></param>
        ///<param name="introduction"></param>
        ///<param name="area"></param>
        public Apply(int id, string name, string role, string email, string fileAddress, string introduction, string area)
        {
			this.Id = id;
			this.Name = name;
			this.Role = role;
			this.Email = email;
			this.FileAddress = fileAddress;
			this.Introduction = introduction;
			this.Area = area;
        }

        #endregion 构造函数

        #region 属性成员

        /// <summary>
        /// 模式元素据
        /// </summary>
        public ApplyMeta SchemaMeta
        {
            get { return ApplyMeta.Instance; }
        }

        /// <summary>
        /// 实现获取元数据接口哦
        /// </summary>
        protected override IMetadata Meta
        {
            get
            {
                return this.SchemaMeta;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return GetValue<int>(ApplyMeta.ColumnNames.Id); }
			set { SetValue(ApplyMeta.ColumnNames.Id, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.Name); }
			set { SetValue(ApplyMeta.ColumnNames.Name, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Role
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.Role); }
			set { SetValue(ApplyMeta.ColumnNames.Role, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.Email); }
			set { SetValue(ApplyMeta.ColumnNames.Email, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string FileAddress
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.FileAddress); }
			set { SetValue(ApplyMeta.ColumnNames.FileAddress, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Introduction
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.Introduction); }
			set { SetValue(ApplyMeta.ColumnNames.Introduction, value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			get { return GetValue<string>(ApplyMeta.ColumnNames.Area); }
			set { SetValue(ApplyMeta.ColumnNames.Area, value); }
		}

        #endregion 属性成员
    }
    
    #endregion
    
    #region 实体查询类

    /// <summary>
    /// 表示实体动态查询
    /// </summary>
    public partial class ApplyQuery : DynamicQuery
    {
        /// <summary>
        /// 构造实体动态查询实例对象
        /// </summary>
        public ApplyQuery()
        {

        }

        /// <summary>
        /// 构造实体动态查询实例对象
        /// </summary>
        /// <param name="joinAlias">级联查询的别名</param>
        public ApplyQuery(string joinAlias)
            : base(joinAlias)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Id
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Id, typeof(int));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Name
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Name, typeof(string));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Role
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Role, typeof(string));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Email
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Email, typeof(string));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem FileAddress
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.FileAddress, typeof(string));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Introduction
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Introduction, typeof(string));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryItem Area
        {
            get
            {
				return new QueryItem(this, ApplyMeta.ColumnNames.Area, typeof(string));
            }
        }

        /// <summary>
        /// 模式元素据
        /// </summary>
        public ApplyMeta SchemaMeta
        {
            get { return ApplyMeta.Instance; }
        }

        /// <summary>
        /// 实现获取元数据
        /// </summary>
        protected override IMetadata Meta
        {
            get { return this.SchemaMeta; }
        }
    }

    #endregion
}