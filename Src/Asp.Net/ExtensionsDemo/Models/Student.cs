using System;
using SqlSugar;

namespace ExtensionsDemo
{
    [SugarTable("STudent")]
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "ID")]
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        [SugarColumn(IsIgnore=true)]
        public int TestId { get; set; }
    }
 
}
