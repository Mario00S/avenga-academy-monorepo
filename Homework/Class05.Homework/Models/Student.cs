namespace Class05.Homework.Models
{
    internal class Student
    {

        public Student()
        {
            
        }

        public Student(string name, string academy, string group)
        {
            Name = name;
            Academy = academy;
            Group = group;
        }

        public string Name { get; set; }
        public string Academy { get; set; }
        public string Group { get; set; }
    }
}
