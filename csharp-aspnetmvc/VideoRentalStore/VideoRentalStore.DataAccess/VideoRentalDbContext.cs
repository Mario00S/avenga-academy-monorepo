using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess
{
    public class VideoRentalDbContext : DbContext
    {
        public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Rental>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Cast>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.CastMembers)
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Matrix",
                    Genre = Genre.SciFi,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(1999, 3, 31),
                    Length = TimeSpan.FromMinutes(136),
                    AgeRestriction = 16,
                    Quantity = 5
                },
    new Movie
    {
        Id = 2,
        Title = "Inception",
        Genre = Genre.SciFi,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2010, 7, 16),
        Length = TimeSpan.FromMinutes(148),
        AgeRestriction = 13,
        Quantity = 3
    },
    new Movie
    {
        Id = 3,
        Title = "Titanic",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(1997, 12, 19),
        Length = TimeSpan.FromMinutes(195),
        AgeRestriction = 12,
        Quantity = 4
    },
    new Movie
    {
        Id = 4,
        Title = "The Godfather",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(1972, 3, 24),
        Length = TimeSpan.FromMinutes(175),
        AgeRestriction = 18,
        Quantity = 2
    },
    new Movie
    {
        Id = 5,
        Title = "Interstellar",
        Genre = Genre.SciFi,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2014, 11, 7),
        Length = TimeSpan.FromMinutes(169),
        AgeRestriction = 13,
        Quantity = 6
    },
    new Movie
    {
        Id = 6,
        Title = "The Dark Knight",
        Genre = Genre.Action,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2008, 7, 18),
        Length = TimeSpan.FromMinutes(152),
        AgeRestriction = 13,
        Quantity = 5
    },
    new Movie
    {
        Id = 7,
        Title = "Pulp Fiction",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(1994, 10, 14),
        Length = TimeSpan.FromMinutes(154),
        AgeRestriction = 18,
        Quantity = 2
    },
    new Movie
    {
        Id = 8,
        Title = "Avengers: Endgame",
        Genre = Genre.Action,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2019, 4, 26),
        Length = TimeSpan.FromMinutes(181),
        AgeRestriction = 13,
        Quantity = 7
    },
    new Movie
    {
        Id = 9,
        Title = "Parasite",
        Genre = Genre.Drama,
        Language = Language.Korean,
        IsAvailable = true,
        ReleaseDate = new DateTime(2019, 5, 30),
        Length = TimeSpan.FromMinutes(132),
        AgeRestriction = 16,
        Quantity = 4
    },
    new Movie
    {
        Id = 10,
        Title = "Spirited Away",
        Genre = Genre.Animation,
        Language = Language.Japanese,
        IsAvailable = true,
        ReleaseDate = new DateTime(2001, 7, 20),
        Length = TimeSpan.FromMinutes(125),
        AgeRestriction = 7,
        Quantity = 5
    },
        new Movie
        {
            Id = 11,
            Title = "Fight Club",
            Genre = Genre.Drama,
            Language = Language.English,
            IsAvailable = true,
            ReleaseDate = new DateTime(1999, 10, 15),
            Length = TimeSpan.FromMinutes(139),
            AgeRestriction = 18,
            Quantity = 4
        },
    new Movie
    {
        Id = 12,
        Title = "The Shawshank Redemption",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(1994, 9, 23),
        Length = TimeSpan.FromMinutes(142),
        AgeRestriction = 16,
        Quantity = 6
    },
    new Movie
    {
        Id = 13,
        Title = "Gladiator",
        Genre = Genre.Action,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(2000, 5, 5),
        Length = TimeSpan.FromMinutes(155),
        AgeRestriction = 16,
        Quantity = 3
    },
    new Movie
    {
        Id = 14,
        Title = "The Lion King",
        Genre = Genre.Animation,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(1994, 6, 24),
        Length = TimeSpan.FromMinutes(88),
        AgeRestriction = 7,
        Quantity = 8
    },
    new Movie
    {
        Id = 15,
        Title = "La La Land",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2016, 12, 9),
        Length = TimeSpan.FromMinutes(128),
        AgeRestriction = 12,
        Quantity = 5
    },
    new Movie
    {
        Id = 16,
        Title = "The Silence of the Lambs",
        Genre = Genre.Horror,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(1991, 2, 14),
        Length = TimeSpan.FromMinutes(118),
        AgeRestriction = 18,
        Quantity = 2
    },
    new Movie
    {
        Id = 17,
        Title = "Coco",
        Genre = Genre.Animation,
        Language = Language.Spanish,
        IsAvailable = true,
        ReleaseDate = new DateTime(2017, 11, 22),
        Length = TimeSpan.FromMinutes(105),
        AgeRestriction = 7,
        Quantity = 7
    },
    new Movie
    {
        Id = 18,
        Title = "The Prestige",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2006, 10, 20),
        Length = TimeSpan.FromMinutes(130),
        AgeRestriction = 13,
        Quantity = 4
    },
    new Movie
    {
        Id = 19,
        Title = "Amélie",
        Genre = Genre.Comedy,
        Language = Language.French,
        IsAvailable = true,
        ReleaseDate = new DateTime(2001, 4, 25),
        Length = TimeSpan.FromMinutes(122),
        AgeRestriction = 12,
        Quantity = 3
    },
    new Movie
    {
        Id = 20,
        Title = "Pan's Labyrinth",
        Genre = Genre.Fantasy,
        Language = Language.Spanish,
        IsAvailable = true,
        ReleaseDate = new DateTime(2006, 10, 11),
        Length = TimeSpan.FromMinutes(118),
        AgeRestriction = 16,
        Quantity = 2
    },
        new Movie
        {
            Id = 21,
            Title = "The Lord of the Rings: The Fellowship of the Ring",
            Genre = Genre.Fantasy,
            Language = Language.English,
            IsAvailable = true,
            ReleaseDate = new DateTime(2001, 12, 19),
            Length = TimeSpan.FromMinutes(178),
            AgeRestriction = 12,
            Quantity = 6
        },
    new Movie
    {
        Id = 22,
        Title = "The Lord of the Rings: The Two Towers",
        Genre = Genre.Fantasy,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2002, 12, 18),
        Length = TimeSpan.FromMinutes(179),
        AgeRestriction = 12,
        Quantity = 6
    },
    new Movie
    {
        Id = 23,
        Title = "The Lord of the Rings: The Return of the King",
        Genre = Genre.Fantasy,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(2003, 12, 17),
        Length = TimeSpan.FromMinutes(201),
        AgeRestriction = 12,
        Quantity = 5
    },
    new Movie
    {
        Id = 24,
        Title = "The Avengers",
        Genre = Genre.Action,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2012, 5, 4),
        Length = TimeSpan.FromMinutes(143),
        AgeRestriction = 13,
        Quantity = 7
    },
    new Movie
    {
        Id = 25,
        Title = "Guardians of the Galaxy",
        Genre = Genre.SciFi,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2014, 8, 1),
        Length = TimeSpan.FromMinutes(121),
        AgeRestriction = 13,
        Quantity = 6
    },
    new Movie
    {
        Id = 26,
        Title = "Black Panther",
        Genre = Genre.Action,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2018, 2, 16),
        Length = TimeSpan.FromMinutes(134),
        AgeRestriction = 13,
        Quantity = 8
    },
    new Movie
    {
        Id = 27,
        Title = "Joker",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = false,
        ReleaseDate = new DateTime(2019, 10, 4),
        Length = TimeSpan.FromMinutes(122),
        AgeRestriction = 18,
        Quantity = 3
    },
    new Movie
    {
        Id = 28,
        Title = "The Social Network",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2010, 10, 1),
        Length = TimeSpan.FromMinutes(120),
        AgeRestriction = 13,
        Quantity = 4
    },
    new Movie
    {
        Id = 29,
        Title = "The Grand Budapest Hotel",
        Genre = Genre.Comedy,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2014, 3, 28),
        Length = TimeSpan.FromMinutes(99),
        AgeRestriction = 12,
        Quantity = 5
    },
    new Movie
    {
        Id = 30,
        Title = "Whiplash",
        Genre = Genre.Drama,
        Language = Language.English,
        IsAvailable = true,
        ReleaseDate = new DateTime(2014, 10, 10),
        Length = TimeSpan.FromMinutes(106),
        AgeRestriction = 16,
        Quantity = 4
    }
                );

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cast>().HasData(
                // The Matrix (MovieId = 1)
                new Cast { Id = 1, Name = "Keanu Reeves", Role = CastRole.Actor, MovieId = 1 },
                new Cast { Id = 2, Name = "Laurence Fishburne", Role = CastRole.Actor, MovieId = 1 },
                new Cast { Id = 3, Name = "Carrie-Anne Moss", Role = CastRole.Actor, MovieId = 1 },
                new Cast { Id = 4, Name = "Lana Wachowski", Role = CastRole.Director, MovieId = 1 },
                new Cast { Id = 5, Name = "Joel Silver", Role = CastRole.Producer, MovieId = 1 },

                // Inception (MovieId = 2)
                new Cast { Id = 6, Name = "Leonardo DiCaprio", Role = CastRole.Actor, MovieId = 2 },
                new Cast { Id = 7, Name = "Joseph Gordon-Levitt", Role = CastRole.Actor, MovieId = 2 },
                new Cast { Id = 8, Name = "Elliot Page", Role = CastRole.Actor, MovieId = 2 },
                new Cast { Id = 9, Name = "Christopher Nolan", Role = CastRole.Director, MovieId = 2 },
                new Cast { Id = 10, Name = "Emma Thomas", Role = CastRole.Producer, MovieId = 2 },

                // Titanic (MovieId = 3)
                new Cast { Id = 11, Name = "Leonardo DiCaprio", Role = CastRole.Actor, MovieId = 3 },
                new Cast { Id = 12, Name = "Kate Winslet", Role = CastRole.Actor, MovieId = 3 },
                new Cast { Id = 13, Name = "Billy Zane", Role = CastRole.Actor, MovieId = 3 },
                new Cast { Id = 14, Name = "James Cameron", Role = CastRole.Director, MovieId = 3 },
                new Cast { Id = 15, Name = "Jon Landau", Role = CastRole.Producer, MovieId = 3 },

                // The Godfather (MovieId = 4)
                new Cast { Id = 16, Name = "Marlon Brando", Role = CastRole.Actor, MovieId = 4 },
                new Cast { Id = 17, Name = "Al Pacino", Role = CastRole.Actor, MovieId = 4 },
                new Cast { Id = 18, Name = "James Caan", Role = CastRole.Actor, MovieId = 4 },
                new Cast { Id = 19, Name = "Francis Ford Coppola", Role = CastRole.Director, MovieId = 4 },
                new Cast { Id = 20, Name = "Albert S. Ruddy", Role = CastRole.Producer, MovieId = 4 },

                // Interstellar (MovieId = 5)
                new Cast { Id = 21, Name = "Matthew McConaughey", Role = CastRole.Actor, MovieId = 5 },
                new Cast { Id = 22, Name = "Anne Hathaway", Role = CastRole.Actor, MovieId = 5 },
                new Cast { Id = 23, Name = "Jessica Chastain", Role = CastRole.Actor, MovieId = 5 },
                new Cast { Id = 24, Name = "Christopher Nolan", Role = CastRole.Director, MovieId = 5 },
                new Cast { Id = 25, Name = "Emma Thomas", Role = CastRole.Producer, MovieId = 5 },

                // The Dark Knight (MovieId = 6)
                new Cast { Id = 26, Name = "Christian Bale", Role = CastRole.Actor, MovieId = 6 },
                new Cast { Id = 27, Name = "Heath Ledger", Role = CastRole.Actor, MovieId = 6 },
                new Cast { Id = 28, Name = "Aaron Eckhart", Role = CastRole.Actor, MovieId = 6 },
                new Cast { Id = 29, Name = "Christopher Nolan", Role = CastRole.Director, MovieId = 6 },
                new Cast { Id = 30, Name = "Charles Roven", Role = CastRole.Producer, MovieId = 6 },

                // Pulp Fiction (MovieId = 7)
                new Cast { Id = 31, Name = "John Travolta", Role = CastRole.Actor, MovieId = 7 },
                new Cast { Id = 32, Name = "Samuel L. Jackson", Role = CastRole.Actor, MovieId = 7 },
                new Cast { Id = 33, Name = "Uma Thurman", Role = CastRole.Actor, MovieId = 7 },
                new Cast { Id = 34, Name = "Quentin Tarantino", Role = CastRole.Director, MovieId = 7 },
                new Cast { Id = 35, Name = "Lawrence Bender", Role = CastRole.Producer, MovieId = 7 },

                // Avengers: Endgame (MovieId = 8)
                new Cast { Id = 36, Name = "Robert Downey Jr.", Role = CastRole.Actor, MovieId = 8 },
                new Cast { Id = 37, Name = "Chris Evans", Role = CastRole.Actor, MovieId = 8 },
                new Cast { Id = 38, Name = "Scarlett Johansson", Role = CastRole.Actor, MovieId = 8 },
                new Cast { Id = 39, Name = "Anthony Russo", Role = CastRole.Director, MovieId = 8 },
                new Cast { Id = 40, Name = "Kevin Feige", Role = CastRole.Producer, MovieId = 8 },

                // Parasite (MovieId = 9)
                new Cast { Id = 41, Name = "Song Kang-ho", Role = CastRole.Actor, MovieId = 9 },
                new Cast { Id = 42, Name = "Cho Yeo-jeong", Role = CastRole.Actor, MovieId = 9 },
                new Cast { Id = 43, Name = "Choi Woo-shik", Role = CastRole.Actor, MovieId = 9 },
                new Cast { Id = 44, Name = "Bong Joon-ho", Role = CastRole.Director, MovieId = 9 },
                new Cast { Id = 45, Name = "Kwak Sin-ae", Role = CastRole.Producer, MovieId = 9 },

                // Spirited Away (MovieId = 10)
                new Cast { Id = 46, Name = "Rumi Hiiragi", Role = CastRole.Actor, MovieId = 10 },
                new Cast { Id = 47, Name = "Miyu Irino", Role = CastRole.Actor, MovieId = 10 },
                new Cast { Id = 48, Name = "Mari Natsuki", Role = CastRole.Actor, MovieId = 10 },
                new Cast { Id = 49, Name = "Hayao Miyazaki", Role = CastRole.Director, MovieId = 10 },
                new Cast { Id = 50, Name = "Toshio Suzuki", Role = CastRole.Producer, MovieId = 10 },

                 new Cast { Id = 51, Name = "Brad Pitt", Role = CastRole.Actor, MovieId = 11 },
        new Cast { Id = 52, Name = "Edward Norton", Role = CastRole.Actor, MovieId = 11 },
        new Cast { Id = 53, Name = "Helena Bonham Carter", Role = CastRole.Actor, MovieId = 11 },
        new Cast { Id = 54, Name = "David Fincher", Role = CastRole.Director, MovieId = 11 },
        new Cast { Id = 55, Name = "Art Linson", Role = CastRole.Producer, MovieId = 11 },

        // The Shawshank Redemption (MovieId = 12)
        new Cast { Id = 56, Name = "Tim Robbins", Role = CastRole.Actor, MovieId = 12 },
        new Cast { Id = 57, Name = "Morgan Freeman", Role = CastRole.Actor, MovieId = 12 },
        new Cast { Id = 58, Name = "Bob Gunton", Role = CastRole.Actor, MovieId = 12 },
        new Cast { Id = 59, Name = "Frank Darabont", Role = CastRole.Director, MovieId = 12 },
        new Cast { Id = 60, Name = "Niki Marvin", Role = CastRole.Producer, MovieId = 12 },

        // Gladiator (MovieId = 13)
        new Cast { Id = 61, Name = "Russell Crowe", Role = CastRole.Actor, MovieId = 13 },
        new Cast { Id = 62, Name = "Joaquin Phoenix", Role = CastRole.Actor, MovieId = 13 },
        new Cast { Id = 63, Name = "Connie Nielsen", Role = CastRole.Actor, MovieId = 13 },
        new Cast { Id = 64, Name = "Ridley Scott", Role = CastRole.Director, MovieId = 13 },
        new Cast { Id = 65, Name = "Douglas Wick", Role = CastRole.Producer, MovieId = 13 },

        // The Lion King (MovieId = 14)
        new Cast { Id = 66, Name = "Matthew Broderick", Role = CastRole.Actor, MovieId = 14 },
        new Cast { Id = 67, Name = "James Earl Jones", Role = CastRole.Actor, MovieId = 14 },
        new Cast { Id = 68, Name = "Jeremy Irons", Role = CastRole.Actor, MovieId = 14 },
        new Cast { Id = 69, Name = "Roger Allers", Role = CastRole.Director, MovieId = 14 },
        new Cast { Id = 70, Name = "Don Hahn", Role = CastRole.Producer, MovieId = 14 },

        // La La Land (MovieId = 15)
        new Cast { Id = 71, Name = "Ryan Gosling", Role = CastRole.Actor, MovieId = 15 },
        new Cast { Id = 72, Name = "Emma Stone", Role = CastRole.Actor, MovieId = 15 },
        new Cast { Id = 73, Name = "John Legend", Role = CastRole.Actor, MovieId = 15 },
        new Cast { Id = 74, Name = "Damien Chazelle", Role = CastRole.Director, MovieId = 15 },
        new Cast { Id = 75, Name = "Fred Berger", Role = CastRole.Producer, MovieId = 15 },

        // The Silence of the Lambs (MovieId = 16)
        new Cast { Id = 76, Name = "Jodie Foster", Role = CastRole.Actor, MovieId = 16 },
        new Cast { Id = 77, Name = "Anthony Hopkins", Role = CastRole.Actor, MovieId = 16 },
        new Cast { Id = 78, Name = "Scott Glenn", Role = CastRole.Actor, MovieId = 16 },
        new Cast { Id = 79, Name = "Jonathan Demme", Role = CastRole.Director, MovieId = 16 },
        new Cast { Id = 80, Name = "Ron Bozman", Role = CastRole.Producer, MovieId = 16 },

        // Coco (MovieId = 17)
        new Cast { Id = 81, Name = "Anthony Gonzalez", Role = CastRole.Actor, MovieId = 17 },
        new Cast { Id = 82, Name = "Gael García Bernal", Role = CastRole.Actor, MovieId = 17 },
        new Cast { Id = 83, Name = "Benjamin Bratt", Role = CastRole.Actor, MovieId = 17 },
        new Cast { Id = 84, Name = "Lee Unkrich", Role = CastRole.Director, MovieId = 17 },
        new Cast { Id = 85, Name = "Darla K. Anderson", Role = CastRole.Producer, MovieId = 17 },

        // The Prestige (MovieId = 18)
        new Cast { Id = 86, Name = "Hugh Jackman", Role = CastRole.Actor, MovieId = 18 },
        new Cast { Id = 87, Name = "Christian Bale", Role = CastRole.Actor, MovieId = 18 },
        new Cast { Id = 88, Name = "Scarlett Johansson", Role = CastRole.Actor, MovieId = 18 },
        new Cast { Id = 89, Name = "Christopher Nolan", Role = CastRole.Director, MovieId = 18 },
        new Cast { Id = 90, Name = "Emma Thomas", Role = CastRole.Producer, MovieId = 18 },

        // Amélie (MovieId = 19)
        new Cast { Id = 91, Name = "Audrey Tautou", Role = CastRole.Actor, MovieId = 19 },
        new Cast { Id = 92, Name = "Mathieu Kassovitz", Role = CastRole.Actor, MovieId = 19 },
        new Cast { Id = 93, Name = "Rufus", Role = CastRole.Actor, MovieId = 19 },
        new Cast { Id = 94, Name = "Jean-Pierre Jeunet", Role = CastRole.Director, MovieId = 19 },
        new Cast { Id = 95, Name = "Claudie Ossard", Role = CastRole.Producer, MovieId = 19 },

        // Pan's Labyrinth (MovieId = 20)
        new Cast { Id = 96, Name = "Ivana Baquero", Role = CastRole.Actor, MovieId = 20 },
        new Cast { Id = 97, Name = "Sergi López", Role = CastRole.Actor, MovieId = 20 },
        new Cast { Id = 98, Name = "Maribel Verdú", Role = CastRole.Actor, MovieId = 20 },
        new Cast { Id = 99, Name = "Guillermo del Toro", Role = CastRole.Director, MovieId = 20 },
        new Cast { Id = 100, Name = "Álvaro Augustín", Role = CastRole.Producer, MovieId = 20 },

// The Lord of the Rings: The Fellowship of the Ring (MovieId = 21)
new Cast { Id = 101, Name = "Elijah Wood", Role = CastRole.Actor, MovieId = 21 },
new Cast { Id = 102, Name = "Ian McKellen", Role = CastRole.Actor, MovieId = 21 },
new Cast { Id = 103, Name = "Orlando Bloom", Role = CastRole.Actor, MovieId = 21 },
new Cast { Id = 104, Name = "Peter Jackson", Role = CastRole.Director, MovieId = 21 },
new Cast { Id = 105, Name = "Barrie M. Osborne", Role = CastRole.Producer, MovieId = 21 },

// Avatar (MovieId = 22)
new Cast { Id = 106, Name = "Sam Worthington", Role = CastRole.Actor, MovieId = 22 },
new Cast { Id = 107, Name = "Zoe Saldana", Role = CastRole.Actor, MovieId = 22 },
new Cast { Id = 108, Name = "Sigourney Weaver", Role = CastRole.Actor, MovieId = 22 },
new Cast { Id = 109, Name = "James Cameron", Role = CastRole.Director, MovieId = 22 },
new Cast { Id = 110, Name = "Jon Landau", Role = CastRole.Producer, MovieId = 22 },

// The Departed (MovieId = 23)
new Cast { Id = 111, Name = "Leonardo DiCaprio", Role = CastRole.Actor, MovieId = 23 },
new Cast { Id = 112, Name = "Matt Damon", Role = CastRole.Actor, MovieId = 23 },
new Cast { Id = 113, Name = "Jack Nicholson", Role = CastRole.Actor, MovieId = 23 },
new Cast { Id = 114, Name = "Martin Scorsese", Role = CastRole.Director, MovieId = 23 },
new Cast { Id = 115, Name = "Brad Grey", Role = CastRole.Producer, MovieId = 23 },

// Joker (MovieId = 24)
new Cast { Id = 116, Name = "Joaquin Phoenix", Role = CastRole.Actor, MovieId = 24 },
new Cast { Id = 117, Name = "Robert De Niro", Role = CastRole.Actor, MovieId = 24 },
new Cast { Id = 118, Name = "Zazie Beetz", Role = CastRole.Actor, MovieId = 24 },
new Cast { Id = 119, Name = "Todd Phillips", Role = CastRole.Director, MovieId = 24 },
new Cast { Id = 120, Name = "Emma Tillinger Koskoff", Role = CastRole.Producer, MovieId = 24 },

// Schindler's List (MovieId = 25)
new Cast { Id = 121, Name = "Liam Neeson", Role = CastRole.Actor, MovieId = 25 },
new Cast { Id = 122, Name = "Ben Kingsley", Role = CastRole.Actor, MovieId = 25 },
new Cast { Id = 123, Name = "Ralph Fiennes", Role = CastRole.Actor, MovieId = 25 },
new Cast { Id = 124, Name = "Steven Spielberg", Role = CastRole.Director, MovieId = 25 },
new Cast { Id = 125, Name = "Gerald R. Molen", Role = CastRole.Producer, MovieId = 25 },

// The Green Mile (MovieId = 26)
new Cast { Id = 126, Name = "Tom Hanks", Role = CastRole.Actor, MovieId = 26 },
new Cast { Id = 127, Name = "Michael Clarke Duncan", Role = CastRole.Actor, MovieId = 26 },
new Cast { Id = 128, Name = "David Morse", Role = CastRole.Actor, MovieId = 26 },
new Cast { Id = 129, Name = "Frank Darabont", Role = CastRole.Director, MovieId = 26 },
new Cast { Id = 130, Name = "David Valdes", Role = CastRole.Producer, MovieId = 26 },

// Braveheart (MovieId = 27)
new Cast { Id = 131, Name = "Mel Gibson", Role = CastRole.Actor, MovieId = 27 },
new Cast { Id = 132, Name = "Sophie Marceau", Role = CastRole.Actor, MovieId = 27 },
new Cast { Id = 133, Name = "Patrick McGoohan", Role = CastRole.Actor, MovieId = 27 },
new Cast { Id = 134, Name = "Mel Gibson", Role = CastRole.Director, MovieId = 27 },
new Cast { Id = 135, Name = "Alan Ladd Jr.", Role = CastRole.Producer, MovieId = 27 },

// Goodfellas (MovieId = 28)
new Cast { Id = 136, Name = "Ray Liotta", Role = CastRole.Actor, MovieId = 28 },
new Cast { Id = 137, Name = "Robert De Niro", Role = CastRole.Actor, MovieId = 28 },
new Cast { Id = 138, Name = "Joe Pesci", Role = CastRole.Actor, MovieId = 28 },
new Cast { Id = 139, Name = "Martin Scorsese", Role = CastRole.Director, MovieId = 28 },
new Cast { Id = 140, Name = "Irwin Winkler", Role = CastRole.Producer, MovieId = 28 },

// Forrest Gump (MovieId = 29)
new Cast { Id = 141, Name = "Tom Hanks", Role = CastRole.Actor, MovieId = 29 },
new Cast { Id = 142, Name = "Robin Wright", Role = CastRole.Actor, MovieId = 29 },
new Cast { Id = 143, Name = "Gary Sinise", Role = CastRole.Actor, MovieId = 29 },
new Cast { Id = 144, Name = "Robert Zemeckis", Role = CastRole.Director, MovieId = 29 },
new Cast { Id = 145, Name = "Wendy Finerman", Role = CastRole.Producer, MovieId = 29 },

// The Social Network (MovieId = 30)
new Cast { Id = 146, Name = "Jesse Eisenberg", Role = CastRole.Actor, MovieId = 30 },
new Cast { Id = 147, Name = "Andrew Garfield", Role = CastRole.Actor, MovieId = 30 },
new Cast { Id = 148, Name = "Justin Timberlake", Role = CastRole.Actor, MovieId = 30 },
new Cast { Id = 149, Name = "David Fincher", Role = CastRole.Director, MovieId = 30 },
new Cast { Id = 150, Name = "Scott Rudin", Role = CastRole.Producer, MovieId = 30 }
);




            modelBuilder.Entity<Rental>().HasData(
                // Free tier (Alice) → only 2 rentals so far
                new Rental { Id = 1, UserId = 1, MovieId = 2, RentedOn = new DateTime(2026, 7, 31) },
                new Rental { Id = 2, UserId = 1, MovieId = 3, RentedOn = new DateTime(2026, 7, 21) },

                // Basic tier (Bob) → already rented 5 movies this month (limit reached)
                new Rental { Id = 3, UserId = 2, MovieId = 5, RentedOn = new DateTime(2026, 8, 4) },
                new Rental { Id = 4, UserId = 2, MovieId = 6, RentedOn = new DateTime(2026, 8, 3) },
                new Rental { Id = 5, UserId = 2, MovieId = 7, RentedOn = new DateTime(2026, 7, 30) },
                new Rental { Id = 6, UserId = 2, MovieId = 8, RentedOn = new DateTime(2026, 7, 27) },
                new Rental { Id = 7, UserId = 2, MovieId = 9, RentedOn = new DateTime(2026, 7, 25) },

                // Premium tier (Charlie) → multiple rentals across months
                new Rental { Id = 8, UserId = 3, MovieId = 10, RentedOn = new DateTime(2026, 8, 5) },
                new Rental { Id = 9, UserId = 3, MovieId = 11, RentedOn = new DateTime(2026, 6, 5) },

                // Basic tier (Hannah) → only 2 rentals this month (still allowed)
                new Rental { Id = 10, UserId = 8, MovieId = 19, RentedOn = new DateTime(2026, 8, 3) },
                new Rental { Id = 11, UserId = 8, MovieId = 20, RentedOn = new DateTime(2026, 7, 30) }
            
            );

            modelBuilder.Entity<User>().HasData(
        new User { Id = 1, FullName = "Alice Johnson", Age = 25, CardNumber = "CARD001", CreatedOn = new DateTime(2026, 8, 6), SubscriptionType = SubscriptionType.Free, SubscriptionExpiresAt = null, RemainingFreeRentals = 3 },

        new User { Id = 2, FullName = "Bob Smith", Age = 32, CardNumber = "CARD002", CreatedOn = new DateTime(2026, 7, 27), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = new DateTime(2026, 8, 5), RemainingFreeRentals = 0 }, // expired

        new User { Id = 3, FullName = "Charlie Brown", Age = 28, CardNumber = "CARD003", CreatedOn = new DateTime(2026, 6, 6), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = new DateTime(2026, 9, 6), RemainingFreeRentals = 2 }, // active

        new User { Id = 4, FullName = "Diana Prince", Age = 30, CardNumber = "CARD004", CreatedOn = new DateTime(2025, 8, 6), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = new DateTime(2026, 8, 16), RemainingFreeRentals = 1 }, // active

        new User { Id = 5, FullName = "Ethan Hunt", Age = 35, CardNumber = "CARD005", CreatedOn = new DateTime(2026, 6, 22), SubscriptionType = SubscriptionType.Free, SubscriptionExpiresAt = null, RemainingFreeRentals = 0 }, // exhausted free rentals

        new User { Id = 6, FullName = "Fiona Gallagher", Age = 27, CardNumber = "CARD006", CreatedOn = new DateTime(2026, 2, 6), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = new DateTime(2026, 8, 26), RemainingFreeRentals = 2 }, // active

        new User { Id = 7, FullName = "George Miller", Age = 40, CardNumber = "CARD007", CreatedOn = new DateTime(2024, 8, 6), SubscriptionType = SubscriptionType.Premium, SubscriptionExpiresAt = new DateTime(2026, 8, 1), RemainingFreeRentals = 3 }, // expired

        new User { Id = 8, FullName = "Hannah Baker", Age = 22, CardNumber = "CARD008", CreatedOn = new DateTime(2026, 8, 3), SubscriptionType = SubscriptionType.Basic, SubscriptionExpiresAt = new DateTime(2026, 8, 21), RemainingFreeRentals = 1 } // active
    );

            //not necesarilly 
            base.OnModelCreating(modelBuilder);
        }

    }
}
