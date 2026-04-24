namespace Class05.Homework.Models
{
    public class Human
    {

        public Human()
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Human(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public string GetPersonStats()
        {
            return $"First Name:{FirstName} \nLast Name:{LastName} \nAge:{Age}";
        }
    }
}
