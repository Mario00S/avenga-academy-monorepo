using VideoRentalStore.DataAccess.Interfaces;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.DataAccess.Repository;

public class InMemoryMovieRepository : InMemoryRepository<Movie>, IMovieRepository
{
    public InMemoryMovieRepository()
    {
        _entities.AddRange(new List<Movie>
{
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
        new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
        new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
    new Movie {
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
});

    }
    public IEnumerable<Movie> GetAvailableMovies()
    {
       return _entities.Where(m => m.IsAvailable);
    }
    public IEnumerable<Movie> GetPagedMovies(int pageNumber, int pageSize)
    {
        return _entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }

}

