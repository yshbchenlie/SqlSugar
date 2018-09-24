using OrmTest.Models;

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
    }
}
