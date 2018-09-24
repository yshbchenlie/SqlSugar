namespace OrmTest.Models
{
    public class ViewModelStudent:Student
    {

    }
    public class ViewModelStudent2
    {
        public string Name { get; set; }
        public Student Student { get; set; }
    }
}
