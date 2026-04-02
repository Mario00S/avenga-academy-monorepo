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


        public Person(int id, string fName, string lName, int age, Genre favoriteMusicType, List<Song> favoriteSongs)
        {
            Id = id;
            FirstName = fName;
            LastName = lName;
            Age = age;
            FavoriteMusicType = favoriteMusicType;
            FavoriteSongs = favoriteSongs ?? new List<Song>(); 
        }

        public void GetFavSongs()
        {
            if (FavoriteSongs.Count > 0)
            {

                Console.WriteLine($"{FirstName} {LastName} favorite songs are: ");
                Console.WriteLine("===============================================");
                foreach (var song in FavoriteSongs)
                {
                    Console.WriteLine($"- {song.Title}");
                }
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName} hates music");
            }
            Console.WriteLine("===============================================");
        }

    }
}


//Create a class Person with:

//Id
//FirstName
//LastName
//Age
//FavoriteMusicType (Genre enum)
//FavoriteSongs(List of Songs)

//Create a method called GetFavSongs() that:

//Prints all titles of favorite songs
//Or prints a message that the person hates music if the list is empty
