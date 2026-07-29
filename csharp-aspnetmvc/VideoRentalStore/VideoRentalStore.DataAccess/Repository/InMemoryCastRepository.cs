using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess.Repository;

public class InMemoryCastRepository : InMemoryRepository<Cast>, ICastRepository
{
    public InMemoryCastRepository(IEnumerable<Movie> movies)
    {
        var castSeed = new Dictionary<int, List<Cast>>
        {
            [1] = new List<Cast> // The Matrix
    {
        new Cast { Id = 1, Name = "Keanu Reeves", Role = CastRole.Actor },
        new Cast { Id = 2, Name = "Laurence Fishburne", Role = CastRole.Actor },
        new Cast { Id = 3, Name = "Carrie-Anne Moss", Role = CastRole.Actor },
        new Cast { Id = 4, Name = "Lana Wachowski", Role = CastRole.Director },
        new Cast { Id = 5, Name = "Joel Silver", Role = CastRole.Producer }
    },
            [2] = new List<Cast> // Inception
    {
        new Cast { Id = 6, Name = "Leonardo DiCaprio", Role = CastRole.Actor },
        new Cast { Id = 7, Name = "Joseph Gordon-Levitt", Role = CastRole.Actor },
        new Cast { Id = 8, Name = "Elliot Page", Role = CastRole.Actor },
        new Cast { Id = 9, Name = "Christopher Nolan", Role = CastRole.Director },
        new Cast { Id = 10, Name = "Emma Thomas", Role = CastRole.Producer }
    },
            [3] = new List<Cast> // Titanic
    {
        new Cast { Id = 11, Name = "Leonardo DiCaprio", Role = CastRole.Actor },
        new Cast { Id = 12, Name = "Kate Winslet", Role = CastRole.Actor },
        new Cast { Id = 13, Name = "Billy Zane", Role = CastRole.Actor },
        new Cast { Id = 14, Name = "James Cameron", Role = CastRole.Director },
        new Cast { Id = 15, Name = "Jon Landau", Role = CastRole.Producer }
    },
            [4] = new List<Cast> // The Godfather
    {
        new Cast { Id = 16, Name = "Marlon Brando", Role = CastRole.Actor },
        new Cast { Id = 17, Name = "Al Pacino", Role = CastRole.Actor },
        new Cast { Id = 18, Name = "James Caan", Role = CastRole.Actor },
        new Cast { Id = 19, Name = "Francis Ford Coppola", Role = CastRole.Director },
        new Cast { Id = 20, Name = "Albert S. Ruddy", Role = CastRole.Producer }
    },
            [5] = new List<Cast> // Interstellar
    {
        new Cast { Id = 21, Name = "Matthew McConaughey", Role = CastRole.Actor },
        new Cast { Id = 22, Name = "Anne Hathaway", Role = CastRole.Actor },
        new Cast { Id = 23, Name = "Jessica Chastain", Role = CastRole.Actor },
        new Cast { Id = 24, Name = "Christopher Nolan", Role = CastRole.Director },
        new Cast { Id = 25, Name = "Emma Thomas", Role = CastRole.Producer }
    },
            [6] = new List<Cast> // The Dark Knight
    {
        new Cast { Id = 26, Name = "Christian Bale", Role = CastRole.Actor },
        new Cast { Id = 27, Name = "Heath Ledger", Role = CastRole.Actor },
        new Cast { Id = 28, Name = "Aaron Eckhart", Role = CastRole.Actor },
        new Cast { Id = 29, Name = "Christopher Nolan", Role = CastRole.Director },
        new Cast { Id = 30, Name = "Charles Roven", Role = CastRole.Producer }
    },
            [7] = new List<Cast> // Pulp Fiction
    {
        new Cast { Id = 31, Name = "John Travolta", Role = CastRole.Actor },
        new Cast { Id = 32, Name = "Samuel L. Jackson", Role = CastRole.Actor },
        new Cast { Id = 33, Name = "Uma Thurman", Role = CastRole.Actor },
        new Cast { Id = 34, Name = "Quentin Tarantino", Role = CastRole.Director },
        new Cast { Id = 35, Name = "Lawrence Bender", Role = CastRole.Producer }
    },
            [8] = new List<Cast> // Avengers: Endgame
    {
        new Cast { Id = 36, Name = "Robert Downey Jr.", Role = CastRole.Actor },
        new Cast { Id = 37, Name = "Chris Evans", Role = CastRole.Actor },
        new Cast { Id = 38, Name = "Scarlett Johansson", Role = CastRole.Actor },
        new Cast { Id = 39, Name = "Anthony Russo", Role = CastRole.Director },
        new Cast { Id = 40, Name = "Kevin Feige", Role = CastRole.Producer }
    },
            [9] = new List<Cast> // Parasite
    {
        new Cast { Id = 41, Name = "Song Kang-ho", Role = CastRole.Actor },
        new Cast { Id = 42, Name = "Cho Yeo-jeong", Role = CastRole.Actor },
        new Cast { Id = 43, Name = "Choi Woo-shik", Role = CastRole.Actor },
        new Cast { Id = 44, Name = "Bong Joon-ho", Role = CastRole.Director },
        new Cast { Id = 45, Name = "Kwak Sin-ae", Role = CastRole.Producer }
    },
            [10] = new List<Cast> // Spirited Away
    {
        new Cast { Id = 46, Name = "Rumi Hiiragi", Role = CastRole.Actor },
        new Cast { Id = 47, Name = "Miyu Irino", Role = CastRole.Actor },
        new Cast { Id = 48, Name = "Mari Natsuki", Role = CastRole.Actor },
        new Cast { Id = 49, Name = "Hayao Miyazaki", Role = CastRole.Director },
        new Cast { Id = 50, Name = "Toshio Suzuki", Role = CastRole.Producer }
    },


            [11] = new List<Cast> // Fight Club
    {
        new Cast { Id = 51, Name = "Brad Pitt", Role = CastRole.Actor },
        new Cast { Id = 52, Name = "Edward Norton", Role = CastRole.Actor },
        new Cast { Id = 53, Name = "Helena Bonham Carter", Role = CastRole.Actor },
        new Cast { Id = 54, Name = "David Fincher", Role = CastRole.Director },
        new Cast { Id = 55, Name = "Art Linson", Role = CastRole.Producer }
    },
            [12] = new List<Cast> // The Shawshank Redemption
    {
        new Cast { Id = 56, Name = "Tim Robbins", Role = CastRole.Actor },
        new Cast { Id = 57, Name = "Morgan Freeman", Role = CastRole.Actor },
        new Cast { Id = 58, Name = "Bob Gunton", Role = CastRole.Actor },
        new Cast { Id = 59, Name = "Frank Darabont", Role = CastRole.Director },
        new Cast { Id = 60, Name = "Niki Marvin", Role = CastRole.Producer }
    },
            [13] = new List<Cast> // Gladiator
    {
        new Cast { Id = 61, Name = "Russell Crowe", Role = CastRole.Actor },
        new Cast { Id = 62, Name = "Joaquin Phoenix", Role = CastRole.Actor },
        new Cast { Id = 63, Name = "Connie Nielsen", Role = CastRole.Actor },
        new Cast { Id = 64, Name = "Ridley Scott", Role = CastRole.Director },
        new Cast { Id = 65, Name = "Douglas Wick", Role = CastRole.Producer }
    },
            [14] = new List<Cast> // The Lion King
    {
        new Cast { Id = 66, Name = "Matthew Broderick", Role = CastRole.Actor },
        new Cast { Id = 67, Name = "James Earl Jones", Role = CastRole.Actor },
        new Cast { Id = 68, Name = "Jeremy Irons", Role = CastRole.Actor },
        new Cast { Id = 69, Name = "Roger Allers", Role = CastRole.Director },
        new Cast { Id = 70, Name = "Don Hahn", Role = CastRole.Producer }
    },
            [15] = new List<Cast> // La La Land
    {
        new Cast { Id = 71, Name = "Ryan Gosling", Role = CastRole.Actor },
        new Cast { Id = 72, Name = "Emma Stone", Role = CastRole.Actor },
        new Cast { Id = 73, Name = "John Legend", Role = CastRole.Actor },
        new Cast { Id = 74, Name = "Damien Chazelle", Role = CastRole.Director },
        new Cast { Id = 75, Name = "Fred Berger", Role = CastRole.Producer }
    },
            [16] = new List<Cast> // The Silence of the Lambs
    {
        new Cast { Id = 76, Name = "Jodie Foster", Role = CastRole.Actor },
        new Cast { Id = 77, Name = "Anthony Hopkins", Role = CastRole.Actor },
        new Cast { Id = 78, Name = "Scott Glenn", Role = CastRole.Actor },
        new Cast { Id = 79, Name = "Jonathan Demme", Role = CastRole.Director },
        new Cast { Id = 80, Name = "Ron Bozman", Role = CastRole.Producer }
    },
            [17] = new List<Cast> // Coco
    {
        new Cast { Id = 81, Name = "Anthony Gonzalez", Role = CastRole.Actor },
        new Cast { Id = 82, Name = "Gael García Bernal", Role = CastRole.Actor },
        new Cast { Id = 83, Name = "Benjamin Bratt", Role = CastRole.Actor },
        new Cast { Id = 84, Name = "Lee Unkrich", Role = CastRole.Director },
        new Cast { Id = 85, Name = "Darla K. Anderson", Role = CastRole.Producer }
    },
            [18] = new List<Cast> // The Prestige
    {
        new Cast { Id = 86, Name = "Hugh Jackman", Role = CastRole.Actor },
        new Cast { Id = 87, Name = "Christian Bale", Role = CastRole.Actor },
        new Cast { Id = 88, Name = "Scarlett Johansson", Role = CastRole.Actor },
        new Cast { Id = 89, Name = "Christopher Nolan", Role = CastRole.Director },
        new Cast { Id = 90, Name = "Emma Thomas", Role = CastRole.Producer }
    },
            [19] = new List<Cast> // Amélie
    {
        new Cast { Id = 91, Name = "Audrey Tautou", Role = CastRole.Actor },
        new Cast { Id = 92, Name = "Mathieu Kassovitz", Role = CastRole.Actor },
        new Cast { Id = 93, Name = "Rufus", Role = CastRole.Actor },
        new Cast { Id = 94, Name = "Jean-Pierre Jeunet", Role = CastRole.Director },
        new Cast { Id = 95, Name = "Claudie Ossard", Role = CastRole.Producer }
    },
            [20] = new List<Cast> // Pan's Labyrinth
    {
        new Cast { Id = 96, Name = "Ivana Baquero", Role = CastRole.Actor },
        new Cast { Id = 97, Name = "Sergi López", Role = CastRole.Actor },
        new Cast { Id = 98, Name = "Maribel Verdú", Role = CastRole.Actor },
        new Cast { Id = 99, Name = "Guillermo del Toro", Role = CastRole.Director },
        new Cast { Id = 100, Name = "Álvaro Augustín", Role = CastRole.Producer }
    },

            [21] = new List<Cast> // LOTR: Fellowship of the Ring
    {
        new Cast { Id = 101, Name = "Elijah Wood", Role = CastRole.Actor },
        new Cast { Id = 102, Name = "Ian McKellen", Role = CastRole.Actor },
        new Cast { Id = 103, Name = "Orlando Bloom", Role = CastRole.Actor },
        new Cast { Id = 104, Name = "Peter Jackson", Role = CastRole.Director },
        new Cast { Id = 105, Name = "Barrie M. Osborne", Role = CastRole.Producer }
    },
            [22] = new List<Cast> // LOTR: The Two Towers
    {
        new Cast { Id = 106, Name = "Viggo Mortensen", Role = CastRole.Actor },
        new Cast { Id = 107, Name = "Andy Serkis", Role = CastRole.Actor },
        new Cast { Id = 108, Name = "Karl Urban", Role = CastRole.Actor },
        new Cast { Id = 109, Name = "Peter Jackson", Role = CastRole.Director },
        new Cast { Id = 110, Name = "Fran Walsh", Role = CastRole.Producer }
    },
            [23] = new List<Cast> // LOTR: Return of the King
    {
        new Cast { Id = 111, Name = "Sean Astin", Role = CastRole.Actor },
        new Cast { Id = 112, Name = "Liv Tyler", Role = CastRole.Actor },
        new Cast { Id = 113, Name = "John Rhys-Davies", Role = CastRole.Actor },
        new Cast { Id = 114, Name = "Peter Jackson", Role = CastRole.Director },
        new Cast { Id = 115, Name = "Michael Lynne", Role = CastRole.Producer }
    },
            [24] = new List<Cast> // The Avengers
    {
        new Cast { Id = 116, Name = "Robert Downey Jr.", Role = CastRole.Actor },
        new Cast { Id = 117, Name = "Chris Hemsworth", Role = CastRole.Actor },
        new Cast { Id = 118, Name = "Mark Ruffalo", Role = CastRole.Actor },
        new Cast { Id = 119, Name = "Joss Whedon", Role = CastRole.Director },
        new Cast { Id = 120, Name = "Kevin Feige", Role = CastRole.Producer }
    },
            [25] = new List<Cast> // Guardians of the Galaxy
    {
        new Cast { Id = 121, Name = "Chris Pratt", Role = CastRole.Actor },
        new Cast { Id = 122, Name = "Zoe Saldana", Role = CastRole.Actor },
        new Cast { Id = 123, Name = "Dave Bautista", Role = CastRole.Actor },
        new Cast { Id = 124, Name = "James Gunn", Role = CastRole.Director },
        new Cast { Id = 125, Name = "Kevin Feige", Role = CastRole.Producer }
    },
            [26] = new List<Cast> // Black Panther
    {
        new Cast { Id = 126, Name = "Chadwick Boseman", Role = CastRole.Actor },
        new Cast { Id = 127, Name = "Michael B. Jordan", Role = CastRole.Actor },
        new Cast { Id = 128, Name = "Lupita Nyong'o", Role = CastRole.Actor },
        new Cast { Id = 129, Name = "Ryan Coogler", Role = CastRole.Director },
        new Cast { Id = 130, Name = "Kevin Feige", Role = CastRole.Producer }
    },
            [27] = new List<Cast> // Joker
    {
        new Cast { Id = 131, Name = "Joaquin Phoenix", Role = CastRole.Actor },
        new Cast { Id = 132, Name = "Robert De Niro", Role = CastRole.Actor },
        new Cast { Id = 133, Name = "Zazie Beetz", Role = CastRole.Actor },
        new Cast { Id = 134, Name = "Todd Phillips", Role = CastRole.Director },
        new Cast { Id = 135, Name = "Bradley Cooper", Role = CastRole.Producer }
    },
            [28] = new List<Cast> // The Social Network
    {
        new Cast { Id = 136, Name = "Jesse Eisenberg", Role = CastRole.Actor },
        new Cast { Id = 137, Name = "Andrew Garfield", Role = CastRole.Actor },
        new Cast { Id = 138, Name = "Justin Timberlake", Role = CastRole.Actor },
        new Cast { Id = 139, Name = "David Fincher", Role = CastRole.Director },
        new Cast { Id = 140, Name = "Scott Rudin", Role = CastRole.Producer }
    },
            [29] = new List<Cast> // The Grand Budapest Hotel
    {
        new Cast { Id = 141, Name = "Ralph Fiennes", Role = CastRole.Actor },
        new Cast { Id = 142, Name = "Tony Revolori", Role = CastRole.Actor },
        new Cast { Id = 143, Name = "Saoirse Ronan", Role = CastRole.Actor },
        new Cast { Id = 144, Name = "Wes Anderson", Role = CastRole.Director },
        new Cast { Id = 145, Name = "Scott Rudin", Role = CastRole.Producer }
    },
            [30] = new List<Cast> // Whiplash
    {
        new Cast { Id = 146, Name = "Miles Teller", Role = CastRole.Actor },
        new Cast { Id = 147, Name = "J.K. Simmons", Role = CastRole.Actor },
        new Cast { Id = 148, Name = "Paul Reiser", Role = CastRole.Actor },
        new Cast { Id = 149, Name = "Damien Chazelle", Role = CastRole.Director },
        new Cast { Id = 150, Name = "Jason Blum", Role = CastRole.Producer }

                // … other movies
            }
        };
        // Unlike AddRange in MovieRepo which just bulk adds movies,
        // this loop also wires up relationships by linking Cast to Movie
        // and populating Movie.CastMembers before adding to the repo.
        //ova e pospor pristap od AddRange vo MoviesRepo ama sakav da probam i drug pristap 
        //- so loop-ot e poblizu do toa kako bi rabotelo so baza kako EF 

        foreach (var movie in movies)
        {
            if (castSeed.TryGetValue(movie.Id, out var castList))
            {
                foreach (var cast in castList)
                {
                    cast.Movie = movie;              // link back
                }
                movie.CastMembers = castList;       // attach to movie
                _entities.AddRange(castList);       // seed into repo
            }
        }
    }

    public IEnumerable<Cast> GetByMovieId(int movieId)
    {
        return _entities.Where(c => c.Movie != null && c.Movie.Id == movieId);
    }
    // We are querying the in-memory list of Cast objects (_entities).
    // Each Cast has a navigation property "Movie" that points back to the Movie it belongs to.
    // In EF Core, navigation properties are automatically populated when you query with Include().
    // Here, we mimic that behavior by wiring Cast.Movie during seeding.
    //
    // The check "c.Movie != null" is defensive coding:
    // - If Cast.Movie was not set during seeding, it would be null.
    // - Accessing c.Movie.Id without this guard would throw a NullReferenceException.
    //
    // Once we confirm Movie is not null, we filter by Movie.Id to return only
    // the cast members that belong to the requested movie.
    //refers to this public IEnumerable<Cast> GetByMovieId(int movieId)
}

