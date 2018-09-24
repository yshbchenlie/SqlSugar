using System;
using SqlSugar;

namespace OrmTest.Models
{
    [SugarTable("STudent")]
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "ID",OracleSequenceName = "seq_newsId")]
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        [SugarColumn(IsIgnore=true)]
        public int TestId { get; set; }
    }
}
