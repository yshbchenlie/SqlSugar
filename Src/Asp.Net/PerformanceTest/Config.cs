using SqlSugar;

namespace PerformanceTest
{
    public class Config
    {
       public static  string connectionString = "server=.;uid=sa;pwd=sasa;database=SqlSugarTest";
       public static ConnectionConfig SugarConfig =new ConnectionConfig() {  IsAutoCloseConnection=true,InitKeyType = InitKeyType.SystemTable, ConnectionString = Config.connectionString, DbType = DbType.SqlServer };
        public static SqlSugarClient GetSugarConn()
        {
            return new SqlSugarClient(SugarConfig);
        }
    }
}
