using SqlSugar;
using OrmTest.Models;

namespace OrmTest.PerformanceTesting
{
    public class SqlSugarPerformance : PerformanceBase
    {
        public SqlSugarPerformance(int eachCount)
        {
            this.count = eachCount;
        }
        public void Select()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = false
            });
            db.IgnoreColumns.Add("TestId", "Student");
            db.Queryable<Student>().Select(it => new ViewModelStudent2 { Name = it.Name, Student = it }).ToList();
            base.Execute("sqlsuagr", () =>
            {
                var test = db.Queryable<Student>().Select(it => new ViewModelStudent2 { Name = it.Name, Student = it }).ToList();
            });
            db.Close();
        }
    }
}
