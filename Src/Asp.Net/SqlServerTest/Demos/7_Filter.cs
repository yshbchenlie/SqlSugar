﻿using OrmTest.Models;
using SqlSugar;
using System.Collections.Generic;

namespace OrmTest.Demo
{
    public class Filter : DemoBase
    {
        public static void Init()
        {


            //gobal filter
            var db = GetInstance1();

            var sql = db.Queryable<Student>().ToSql();
            //SELECT [ID],[SchoolId],[Name],[CreateTime] FROM [STudent]  WHERE  isDelete=0 

            var sql2 = db.Queryable<Student, School>((f, s) => new object[] { JoinType.Left, f.SchoolId == s.Id }).ToSql();
            //SELECT[f].[ID],[f].[SchoolId],[f].[Name],[f].[CreateTime]
            //FROM[STudent] f Left JOIN School s ON([f].[SchoolId] = [s].[Id])   WHERE f.isDelete=0 


            //Specify name filter 
            var sql3 = db.Queryable<Student>().Filter("query1").ToSql();
            //SELECT [ID],[SchoolId],[Name],[CreateTime] FROM [STudent]  WHERE  WHERE  id>@id  AND  isDelete=0 


            //Specify key filter  and disabled global filter
            string key = "query1";
            var sql4 = db.Queryable<Student>().Filter(key,true).ToSql();
            //SELECT [ID],[SchoolId],[Name],[CreateTime] FROM [STudent]  WHERE  WHERE  id>@id  

            var sql5 = db.Ado.GetInt("select {0}");
            //select 1
        }

        public static SqlSugarClient GetInstance1()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            db.QueryFilter
             .Add(new SqlFilterItem()
             {
                 FilterValue = filterDb =>
                 {
                     return new SqlFilterResult() { Sql = " isDelete=0" };
                 },
                 IsJoinQuery = false 
             }).Add(new SqlFilterItem()
             {
                 FilterValue = filterDb =>
                 {
                     return new SqlFilterResult() { Sql = " f.isDelete=0" };
                 },
                 IsJoinQuery = true
             })
            .Add(new SqlFilterItem()
            {
                FilterName = "query1",
                FilterValue = filterDb =>
                {
                    return new SqlFilterResult() { Sql = " id>@id", Parameters = new { id = 1 } };
                },
                IsJoinQuery = false
            });

            //Processing prior to execution of SQL
            db.Ado.ProcessingEventStartingSQL = (sql, par) =>
            {
                if (sql.Contains("{0}"))
                {
                    sql = string.Format(sql, "1");
                }
                return new KeyValuePair<string, SugarParameter[]>(sql,par);
            };
            return db;
        }
    }

}
