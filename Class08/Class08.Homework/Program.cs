//using static System.Net.WebRequestMethods;

//EXERCISE 1
//Create a class Song with:

//Title
//Length
//Genre(enum: Rock, Hip_Hop, Techno, Classical)
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

using Class08.Homework.Enums;
using Class08.Homework.Models;

List<Song> songs = new List<Song>()
{
    new Song("Broken Noise", 4, Genre.Rock),
    new Song("Blue Sky Beat", 7, Genre.Techno),
    new Song("Black Vinyl", 5, Genre.Rock),
    new Song("Bassline Rush", 2, Genre.Hip_Hop),
    new Song("Binary Dreams", 8, Genre.Techno),
    new Song("Midnight Train", 6, Genre.Rock),
    new Song("Golden Hour", 3, Genre.Classical),
    new Song("Echo Street", 2, Genre.Hip_Hop),
    new Song("Velvet Sun", 9, Genre.Classical),
    new Song("Rebel Heart", 4, Genre.Rock),
    new Song("Beat Drop", 2, Genre.Hip_Hop),
    new Song("Silent River", 7, Genre.Classical),
    new Song("Neon Pulse", 5, Genre.Techno),
    new Song("Backspin Flow", 1, Genre.Hip_Hop),
    new Song("Firelight", 6, Genre.Rock)
};



Person[] persons = new Person[]
{
    new Person(1, "Jerry", "Stone", 28, Genre.Rock, new List<Song>()),
    new Person(2, "Maria", "Evans", 24, Genre.Classical, new List<Song>()),
    new Person(3, "Jane", "Cooper", 31, Genre.Rock, new List<Song>()),
    new Person(4, "Stefan", "Petrov", 27, Genre.Hip_Hop, new List<Song>()),

    new Person(5, "Anna", "Miller", 22, Genre.Techno, new List<Song>()
    {
        songs[1],   // Blue Sky Beat
        songs[4],   // Binary Dreams
        songs[12]   // Neon Pulse
    }),

    new Person(6, "Bob", "Jackson", 35, Genre.Rock, new List<Song>()
    {
        songs[0],   // Broken Noise
        songs[2],   // Black Vinyl
        songs[9],   // Rebel Heart
        songs[14]   // Firelight
    }),

    new Person(7, "Elena", "Brown", 26, Genre.Classical, new List<Song>()
    {
        songs[6],   // Golden Hour
        songs[8],   // Velvet Sun
        songs[11]   // Silent River
    }),

    new Person(8, "David", "Wilson", 29, Genre.Hip_Hop, new List<Song>()
    {
        songs[3],   // Bassline Rush
        songs[7],   // Echo Street
        songs[10]   // Beat Drop
    }),

    new Person(9, "Sarah", "White", 33, Genre.Techno, new List<Song>()
    {
        songs[1],   // Blue Sky Beat
        songs[12]   // Neon Pulse
    }),

    new Person(10, "Mark", "Taylor", 30, Genre.Rock, new List<Song>()
    {
        songs[5],   // Midnight Train
        songs[9],   // Rebel Heart
        songs[14]   // Firelight
    }),

    new Person(11, "Nina", "Adams", 21, Genre.Classical, new List<Song>()
    {
        songs[6],   // Golden Hour
        songs[11]   // Silent River
    }),

    new Person(12, "Viktor", "Ivanov", 38, Genre.Hip_Hop, new List<Song>()
    {
        songs[3],   // Bassline Rush
        songs[7],   // Echo Street
        songs[10],  // Beat Drop
        songs[13]   // Backspin Flow
    }),

    new Person(13, "Laura", "Green", 25, Genre.Techno, new List<Song>()
    {
        songs[4],   // Binary Dreams
        songs[1],   // Blue Sky Beat
        songs[12]   // Neon Pulse
    }),

    new Person(14, "Peter", "Novak", 40, Genre.Rock, new List<Song>()
    {
        songs[0],   // Broken Noise
        songs[2],   // Black Vinyl
        songs[5],   // Midnight Train
        songs[9]    // Rebel Heart
    }),

    new Person(15, "Mia", "Torres", 23, Genre.Classical, new List<Song>()
    {
        songs[6],   // Golden Hour
        songs[8],   // Velvet Sun
        songs[11]   // Silent River
    })
};

//Test output
var firstPerson = persons[0];

foreach (var person in persons)
{
    person.GetFavSongs();
}

firstPerson.GetFavSongs();