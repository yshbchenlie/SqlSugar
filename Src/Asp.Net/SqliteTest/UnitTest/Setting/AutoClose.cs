﻿using OrmTest.Models;
using SqlSugar;

namespace OrmTest.UnitTest
{
    public class AutoClose : UnitTestBase
    {
        public AutoClose(int eachCount)
        {
            this.Count = eachCount;
        }
        public void Init()
        {
            //IsAutoCloseConnection
            for (int i = 0; i < this.Count; i++)
            {
                var db = GetInstance();
                var x = db.Queryable<Student>().ToList();
            }
        }
        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionString, DbType = DbType.Sqlite, IsAutoCloseConnection = true });
            return db;
        }
    }
}
