using SqlSugar;

namespace OrmTest.UnitTest
{
    public class MapColumn : UnitTestBase
    {
        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionString, DbType = DbType.SqlServer });
            return db;
        }
    }
}
