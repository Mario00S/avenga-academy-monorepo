using Class08.Homework.Enums;
using Class08.Homework.Models;

namespace Class08.Homework.Models
{
    public class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genre FavoriteMusicType { get; set; }
        public List<Song> FavoriteSongs { get; set; }


    }
}


//Create a class Person with:

//Id
//FirstName
//LastName
//Age
//FavoriteMusicType (Genre enum)
//FavoriteSongs(List of Songs)