using OrmTest.Models;

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
    }
}
