using SqlSugar;
using System;

namespace SqlSugarEx
{
    public class ExSqlSugarClient : SqlSugarClient
    {
        private readonly ConnectionType _connectionType;


        public ExSqlSugarClient(ConnectionConfig config, ConnectionType connectionType) : base(config)
        {
            _connectionType = connectionType;
        }
        /// <summary>
        /// 获取数据库时间
        /// </summary>
        /// <returns></returns>
        public new DateTime GetDate()
        {
            if (_connectionType == ConnectionType.Remote)
            {
                return base.GetDate();
            }
            else
            {
                var sqlBuilder = InstanceFactory.GetSqlbuilder(this.Context.CurrentConnectionConfig);
                string sql = sqlBuilder.FullSqlDateNow;
                //调用远程方法

                return DateTime.Now;
            }
        }






    }
}
