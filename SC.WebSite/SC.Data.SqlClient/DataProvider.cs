/*  ----------------------------------------------------------------------------
 * 项目名： SC
 * 制作开发：Shannon
 * 联系电话：18668803036
 * 网址：http://www.shannon.com
 * Copyright (c) Shannon
 *  ----------------------------------------------------------------------------
 */
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Starsoft.NetUniver.Core;
using Starsoft.NetUniver.Core.Query;
using Starsoft.NetUniver.Core.Business;
using Starsoft.NetUniver.Core.Data;
using Starsoft.NetUniver.SqlClient;

namespace SC.Data.SqlClient
{
    /// <summary>
    /// 数据操作提供者
    /// </summary>
    public abstract class DataProvider : SqlClientProvider, IDataProvider
    {
        [ThreadStatic]
        private static DbConnection __sharedConnection;

        #region 实现接口

        #region 数据库连接相关

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">配置节点名称</param>
        /// <param name="config">配置节点键值对</param>
        public void Initialize(string name, NameValueCollection config)
        {
            this._name = name;

            if (config[ConfigurationPropertyName.CONNECTION_PASSKEY] != null)
            {
                this._passKey = config[ConfigurationPropertyName.CONNECTION_PASSKEY];
            }
            else
            {
                this._passKey = string.Empty;
            }

            if (config[ConfigurationPropertyName.CONNECTION_CATALOG] != null)
            {
                this._catalog = config[ConfigurationPropertyName.CONNECTION_CATALOG];
            }

            if (config[ConfigurationPropertyName.CONNECTION_SCHEMA] != null)
            {
                this._schema = config[ConfigurationPropertyName.CONNECTION_SCHEMA];
            }

            if (config[ConfigurationPropertyName.CONNECTION_STRING] != null)
            {
                string connectionString = config[ConfigurationPropertyName.CONNECTION_STRING];

                this._defaultConnectionString = this.ParseConnectionString(connectionString);
            }
            else
            {
                this._connectionStringName = config[ConfigurationPropertyName.CONNECTION_STRING_NAME];
            }
        }

        /// <summary>
        /// 设置缺省的数据库连接字符串
        /// </summary>
        /// <param name="defaultConnectionString">数据库连接字符串</param>
        public void SetDefaultConnectionString(string defaultConnectionString)
        {
            this._defaultConnectionString = defaultConnectionString;
        }

        /// <summary>
        /// 创建数据库连接对象
        /// </summary>
        /// <returns>数据库连接对象</returns>
        public DbConnection CreateConnection()
        {
            return CreateConnection(this.DefaultConnectionString);
        }

        /// <summary>
        /// 创建数据库连接对象
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>数据库连接对象</returns>
        public DbConnection CreateConnection(string connectionString)
        {
            DbConnection conn = new SqlConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        /// <summary>
        /// 重置共享的数据库连接对象
        /// </summary>
        public void ResetSharedConnection()
        {
            this.CurrentSharedConnection = null;
        }

        /// <summary>
        /// 初始化一个共享的数据库连接对象
        /// </summary>
        /// <returns>共享的数据库连接对象</returns>
        public DbConnection InitializeSharedConnection()
        {
            if (this.CurrentSharedConnection == null)
            {
                this.CurrentSharedConnection = this.CreateConnection();
            }

            return this.CurrentSharedConnection;
        }

        /// <summary>
        /// 初始化一个共享的数据库连接对象
        /// </summary>
        /// <param name="sharedConnectionString">共享的数据库连接字符串</param>
        /// <returns>共享的数据库连接对象</returns>
        public DbConnection InitializeSharedConnection(string sharedConnectionString)
        {
            if (this.CurrentSharedConnection == null)
            {
                this.CurrentSharedConnection = this.CreateConnection(sharedConnectionString);
            }

            return this.CurrentSharedConnection;
        }

        private static void __sharedConnection_Disposed(object sender, EventArgs e)
        {
            __sharedConnection = null;
        }

        /// <summary>
        /// 解析数据库连接字符
        /// </summary>
        /// <param name="connectionString">数据库连接字符</param>
        /// <returns>数据库连接字符</returns>
        private string ParseConnectionString(string connectionString)
        {
            //if (string.IsNullOrEmpty(this._passKey))
            //{
            //    return connectionString;
            //}

            //return Encryption.Decrypt(connectionString, this._passKey);
            return connectionString;
        }

        private string _name;
        /// <summary>
        /// 获取提供者名称
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

        private string _passKey;
        /// <summary>
        /// 获取数据库连接字符串加密密钥
        /// </summary>
        public string PassKey
        {
            get { return this._passKey; }
        }

        /// <summary>
        /// 获取当前共享的数据库连接字符是否为缺省的连接字符
        /// </summary>
        public bool CurrentConnectionStringIsDefault
        {
            get
            {
                if (this.CurrentSharedConnection != null)
                {
                    if (this.CurrentSharedConnection.ConnectionString != this.DefaultConnectionString)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 获取共享的数据库连接对象
        /// </summary>
        public DbConnection CurrentSharedConnection
        {
            get { return __sharedConnection; }
            protected set
            {
                if (value == null)
                {
                    __sharedConnection.Dispose();
                    __sharedConnection = null;
                }
                else
                {
                    __sharedConnection = value;
                    __sharedConnection.Disposed += __sharedConnection_Disposed;
                }
            }
        }

        private string _connectionStringName;
        /// <summary>
        /// 获取或设置数据库连接字符串配置节点的名称
        /// </summary>
        public string ConnectionStringName
        {
            get { return _connectionStringName; }
            set { _connectionStringName = value; }
        }

        private string _defaultConnectionString;
        /// <summary>
        /// 获取或设置缺省的数据库连接字符串
        /// </summary>
        public string DefaultConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(this._defaultConnectionString) && !String.IsNullOrEmpty(this._connectionStringName))
                {
                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings[this._connectionStringName].ConnectionString;

                        this._defaultConnectionString = this.ParseConnectionString(connectionString);
                    }
                    catch
                    {
                        this._defaultConnectionString = "NOT SET";
                    }
                }

                return this._defaultConnectionString;
            }
            set { this._defaultConnectionString = value; }
        }

        #endregion

        #region 执行命令基础方法

        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响的行数。</returns>
        public int ExecuteQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteQuery(cmd);
        }

        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>受影响的行数。</returns>
        public int ExecuteQuery(DbCommand cmd)
        {
            int result;
            using (AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this))
            {
                cmd.Connection = automaticConnectionScope.Connection;
                result = cmd.ExecuteNonQuery();

                if (!automaticConnectionScope.IsUsingSharedConnection)
                {
                    automaticConnectionScope.Connection.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <typeparam name="T">返回结果数据类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）</returns>
        public T ExecuteScalar<T>(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteScalar<T>(cmd);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <typeparam name="T">返回结果数据类型</typeparam>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）</returns>
        public T ExecuteScalar<T>(DbCommand cmd)
        {
            return this.ToType<T>(this.ExecuteScalar(cmd));
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object ExecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object ExecuteScalar(DbCommand cmd)
        {
            object result;
            using (AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this))
            {
                cmd.Connection = automaticConnectionScope.Connection;
                result = cmd.ExecuteScalar();

                if (!automaticConnectionScope.IsUsingSharedConnection)
                {
                    automaticConnectionScope.Connection.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// 执行命令，生成一个DbDataReader，不推荐使用，推荐使用带委托的方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteReader(cmd);
        }

        /// <summary>
        /// 执行命令，生成一个DbDataReader，不推荐使用，推荐使用带委托的方法
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this);
            cmd.Connection = automaticConnectionScope.Connection;
            DbDataReader rdr;
            try
            {
                rdr = automaticConnectionScope.IsUsingSharedConnection ? cmd.ExecuteReader() : cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                // AutoConnectionScope will figure out what to do with the connection
                automaticConnectionScope.Dispose();
                //rethrow retaining stack trace.
                throw;
            }

            return rdr;
        }

        /// <summary>
        /// 执行命令，生成一个DbDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="callback">回调函数</param>
        public void ExecuteReader(string sql, ExecuteReaderHandler callback)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            this.ExecuteReader(cmd, callback);
        }

        /// <summary>
        /// 执行命令，生成一个DbDataReader
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <param name="callback">回调函数</param>
        public void ExecuteReader(DbCommand cmd, ExecuteReaderHandler callback)
        {
            AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this);
            cmd.Connection = automaticConnectionScope.Connection;
            try
            {
                DbDataReader reader = cmd.ExecuteReader();
                callback(reader);
            }
            finally
            {
                if (!automaticConnectionScope.IsUsingSharedConnection)
                {
                    automaticConnectionScope.Connection.Close();
                    automaticConnectionScope.Dispose();
                }
            }
        }

        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>数据表</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>数据表</returns>
        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            DataTable dt = new DataTable();
            this.ExecuteReader(cmd, delegate(DbDataReader dr)
            {
                dt.Load(dr);
                dr.Close();
                dr.Dispose();
            });

            return dt;
        }

        /// <summary>
        /// 执行命令返回DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            return this.ExecuteDataSet<DataSet>(sql);
        }

        /// <summary>
        /// 执行命令返回DataSet
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            return this.ExecuteDataSet<DataSet>(cmd);
        }

        /// <summary>
        /// 执行命令返回DataSet
        /// </summary>
        /// <typeparam name="T">返回的DataSet数据类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns>DataSet</returns>
        public T ExecuteDataSet<T>(string sql) where T : DataSet, new()
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;

            return this.ExecuteDataSet<T>(cmd);
        }

        /// <summary>
        /// 执行命令返回DataSet
        /// </summary>
        /// <typeparam name="T">返回的DataSet数据类型</typeparam>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>DataSet</returns>
        public T ExecuteDataSet<T>(DbCommand cmd) where T : DataSet, new()
        {
            T ds = new T();
            using (AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this))
            {
                cmd.Connection = automaticConnectionScope.Connection;
                DbDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (!automaticConnectionScope.IsUsingSharedConnection)
                {
                    automaticConnectionScope.Connection.Close();
                }
            }

            return ds;
        }

        #endregion

        #region 动态查询相关

        /// <summary>
        /// 只返回单个实体的查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">动态查询</param>
        /// <returns>实体对象实例</returns>
        public T SingleQuery<T>(DynamicQuery query) where T : Entity, new()
        {
            return this.SingleQuery<T>(query, false);
        }

        /// <summary>
        /// 只返回单个实体的查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">动态查询</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>实体对象实例</returns>
        public T SingleQuery<T>(DynamicQuery query, bool convertBlankToNull) where T : Entity, new()
        {
            query.Properties.Top = 1;
            SqlCommand cmd = this.PrepareQueryCommand(query);
            T entity = null;
            this.ExecuteReader(cmd, delegate(DbDataReader dr)
            {
                entity = this.ConvertEntity<T>(dr, convertBlankToNull);
                dr.Close();
                dr.Dispose();
            });

            return entity;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">动态查询</param>
        /// <returns>实体集合</returns>
        public TList<T> Query<T>(DynamicQuery query) where T : Entity, new()
        {
            return this.Query<T>(query, false);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">动态查询</param>
        /// <param name="convertBlankToNull">是否当实体属性没设置时，转化属性的空白值为对应的类型的默认值</param>
        /// <returns>实体集合</returns>
        public TList<T> Query<T>(DynamicQuery query, bool convertBlankToNull) where T : Entity, new()
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);
            TList<T> rows = new TList<T>();
            this.ExecuteReader(cmd, delegate(DbDataReader dr)
            {
                this.Fill<T>(dr, rows, convertBlankToNull);
                dr.Close();
                dr.Dispose();
            });

            return rows;
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <typeparam name="T">返回结构基础数据的类型</typeparam>
        /// <param name="query"></param>
        /// <returns>基础数据</returns>
        public T ExecuteScalar<T>(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteScalar<T>(cmd);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object ExecuteScalar(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteQuery(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteQuery(cmd);
        }

        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>数据表</returns>
        public DataTable ExecuteDataTable(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 执行命令返回DataSet
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteDataSet(cmd);
        }

        /// <summary>
        /// 执行插入查询并返回受影响的行数。
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteInsertQuery(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareInsertCommand(query);

            return this.ExecuteQuery(cmd);
        }

        /// <summary>
        /// 执行插入查询并返回受影响的行数
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <param name="identityColumn">标识列</param>
        /// <param name="identityPara">标识列输出参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteInsertQuery(DynamicQuery query, QueryItem identityColumn, out SqlParameter identityPara)
        {
            SqlCommand cmd = this.PrepareInsertCommand(query, identityColumn, out identityPara);

            return this.ExecuteQuery(cmd);
        }

        /// <summary>
        /// 执行更新查询并返回受影响的行数。
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteUpdateQuery(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareUpdateCommand(query);

            return this.ExecuteQuery(cmd);
        }

        /// <summary>
        /// 执行删除查询并返回受影响的行数。
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteDeleteQuery(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareDeleteCommand(query);

            return this.ExecuteQuery(cmd);
        }
		
        /// <summary>
        /// 执行命令，生成一个DbDataReader，不推荐使用，推荐使用带委托的方法
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(DynamicQuery query)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            return this.ExecuteReader(cmd);
        }

        /// <summary>
        /// 执行命令，生成一个DbDataReader
        /// </summary>
        /// <param name="query"></param>
        /// <param name="callback"></param>
        public void ExecuteReader(DynamicQuery query, ExecuteReaderHandler callback)
        {
            SqlCommand cmd = this.PrepareQueryCommand(query);

            this.ExecuteReader(cmd, callback);
        }

        #endregion

        #endregion

        /// <summary>
        /// 将源数据类型隐式转换为目标数据类型
        /// </summary>
        /// <typeparam name="T">返回结果数据类型</typeparam>
        /// <param name="oVal">要隐式转换的值</param>
        /// <returns>转换后的值</returns>
        public T ToType<T>(object oVal)
        {
            if (oVal == null || oVal == DBNull.Value)
            {
                return default(T);
            }

            return (T)oVal;
        }

        /// <summary>
        /// 将数据表填充为实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="table">数据表</param>
        /// <param name="rows">实体集合</param>
        /// <returns>实体集合</returns>
        internal TList<T> Fill<T>(DataTable table, TList<T> rows) where T : Entity, new()
        {
            return Fill<T>(table, rows, false);
        }

        /// <summary>
        /// 将数据表填充为实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="table">数据表</param>
        /// <param name="rows">实体集合</param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <returns>实体集合</returns>
        internal TList<T> Fill<T>(DataTable table, TList<T> rows, bool convertBlankToNull) where T : Entity, new()
        {
            foreach (DataRow dr in table.Rows)
            {
                T entity = new T();
                entity.ConvertBlankToNull = convertBlankToNull;
                entity.SuppressEntityEvents = true;
                foreach (DataColumn column in table.Columns)
                {
                    object fieldValue = dr[column];
                    if (Convert.IsDBNull(fieldValue))
                    {
                        fieldValue = null;
                    }
                    entity.SetValue(column.ColumnName, fieldValue);
                }
                entity.AcceptChanges();
                entity.SuppressEntityEvents = false;
                rows.Add(entity);
            }

            return rows;
        }

        /// <summary>
        /// 将只进结果集流填充为实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="reader">只进结果集流</param>
        /// <param name="rows">实体集合</param>
        /// <returns>实体集合</returns>
        internal TList<T> Fill<T>(IDataReader reader, TList<T> rows) where T : Entity, new()
        {
            return Fill<T>(reader, rows, false);
        }

        /// <summary>
        /// 将只进结果集流填充为实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="reader">只进结果集流</param>
        /// <param name="rows">实体集合</param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <returns>实体集合</returns>
        internal TList<T> Fill<T>(IDataReader reader, TList<T> rows, bool convertBlankToNull) where T : Entity, new()
        {
            while (reader.Read())
            {
                T entity = new T();
                entity.ConvertBlankToNull = convertBlankToNull;
                entity.SuppressEntityEvents = true;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string fieldName = reader.GetName(i);
                    object fieldValue = reader.GetValue(i);
                    if (reader.IsDBNull(i))
                    {
                        fieldValue = null;
                    }
                    entity.SetValue(fieldName, fieldValue);
                }
                entity.AcceptChanges();
                entity.SuppressEntityEvents = false;
                rows.Add(entity);
            }

            return rows;
        }

        /// <summary>
        /// 将只进结果集流转换为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="reader">只进结果集流</param>
        /// <returns>实体</returns>
        internal T ConvertEntity<T>(IDataReader reader) where T : Entity, new()
        {
            return this.ConvertEntity<T>(reader, false);
        }

        /// <summary>
        /// 将只进结果集流转换为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="reader">只进结果集流</param>
        /// <param name="convertBlankToNull">设置当获取实体属性的值时是否取没被设置的实体的属性的缺省值还是抛出异常</param>
        /// <returns>实体</returns>
        internal T ConvertEntity<T>(IDataReader reader, bool convertBlankToNull) where T : Entity, new()
        {
            if (!reader.Read())
            {
                return null;
            }
            T entity = new T();
            entity.ConvertBlankToNull = convertBlankToNull;
            entity.SuppressEntityEvents = true;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldName = reader.GetName(i);
                object fieldValue = reader.GetValue(i);
                if (reader.IsDBNull(i))
                {
                    fieldValue = null;
                }
                entity.SetValue(fieldName, fieldValue);
            }
            entity.AcceptChanges();
            entity.SuppressEntityEvents = false;

            return entity;
        }

        /// <summary>
        /// 将动态查询转换为数据库执行命令
        /// </summary>
        /// <param name="query">动态查询</param>
        /// <returns>数据库执行命令</returns>
        internal SqlCommand PrepareQueryCommand(DynamicQuery query)
        {
            this.PopulateDynamicQuery(query);
            SqlCommand cmd = new SqlCommand();
            int pindex = this.NextParamIndex(cmd);
            string sql = this.BuildQuerySql(query, cmd, ref pindex);
            query.Properties.LastQuery = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 将插入动态查询转换为数据库执行命令
        /// </summary>
        /// <param name="query">插入动态查询</param>
        /// <returns>数据库执行命令</returns>
        internal SqlCommand PrepareInsertCommand(DynamicQuery query)
        {
            this.PopulateDynamicQuery(query);
            SqlCommand cmd = new SqlCommand();
            int pindex = this.NextParamIndex(cmd);
            string sql = this.BuildInsertSql(query, cmd, ref pindex);
            query.Properties.LastQuery = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 将插入动态查询转换为数据库执行命令
        /// </summary>
        /// <param name="query">插入动态查询</param>
        /// <param name="identityColumn">标识列</param>
        /// <param name="identityPara">标识列输出参数</param>
        /// <returns>数据库执行命令</returns>
        internal SqlCommand PrepareInsertCommand(DynamicQuery query, QueryItem identityColumn, out SqlParameter identityPara)
        {
            this.PopulateDynamicQuery(query);
            SqlCommand cmd = new SqlCommand();
            int pindex = this.NextParamIndex(cmd);
            string sql = this.BuildInsertSql(query, cmd, ref pindex, identityColumn, out identityPara);
            query.Properties.LastQuery = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 将更新动态查询转换为数据库执行命令
        /// </summary>
        /// <param name="query">更新动态查询</param>
        /// <returns>数据库执行命令</returns>
        internal SqlCommand PrepareUpdateCommand(DynamicQuery query)
        {
            this.PopulateDynamicQuery(query);
            SqlCommand cmd = new SqlCommand();
            int pindex = this.NextParamIndex(cmd);
            string sql = this.BuildUpdateSql(query, cmd, ref pindex);
            query.Properties.LastQuery = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 将删除动态查询转换为数据库执行命令
        /// </summary>
        /// <param name="query">删除动态查询</param>
        /// <returns>数据库执行命令</returns>
        internal SqlCommand PrepareDeleteCommand(DynamicQuery query)
        {
            this.PopulateDynamicQuery(query);
            SqlCommand cmd = new SqlCommand();
            int pindex = this.NextParamIndex(cmd);
            string sql = this.BuildDeleteSql(query, cmd, ref pindex);
            query.Properties.LastQuery = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 取得命令参数的索引
        /// </summary>
        /// <param name="cmd">数据库执行命令</param>
        /// <returns>命令参数索引</returns>
        private int NextParamIndex(SqlCommand cmd)
        {
            return cmd.Parameters.Count;
        }

        /// <summary>
        /// 根提供者相关联的数据信息初始化动态查询
        /// </summary>
        /// <param name="query">动态查询</param>
        private void PopulateDynamicQuery(DynamicQuery query)
        {
            DynamicQuery.HookupWithNoLock(query);
        }

        private string _catalog;
        /// <summary>
        /// 
        /// </summary>
        public override string Catalog
        {
            get { return this._catalog; }
        }

        private string _schema;
        /// <summary>
        /// 
        /// </summary>
        public override string Schema
        {
            get { return this._schema; }
        }
    }
}
