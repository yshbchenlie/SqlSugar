using SqlSugar;

namespace OrmTest.Models
{
    public class School
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
