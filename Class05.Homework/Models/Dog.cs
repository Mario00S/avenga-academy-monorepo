namespace Class05.Homework.Models
{
    public class Dog
    {
        public Dog()
        {
            
        }

        public Dog(string name, string race, string color)
        {
            Name = name;
            Race = race;
            Color = color;
        }

        public string Name { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }


        public string Eat()
        {
            return $"The dog named: {Name} is now eating.";
        }

        public string Play()
        {
            return $"The dog named: {Name} race: {Race}, color: {Color} is now playing.";
        }

        public string ChaseTail() 
        {
            return ($"The dog {Name} is now chasing its tail.");
        }
    }
}