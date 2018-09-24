using OrmTest.Models;
using SqlSugar;

namespace OrmTest.UnitTest
{
    public class MapTable : UnitTestBase
    {
        public void Init()
        {
            //IsAutoCloseConnection
            for (int i = 0; i < 200; i++)
            {
                var db = GetInstance();
                var x = db.Queryable<Student>().ToList(); 
            }
        }
        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            return db;
        }
    }
}
