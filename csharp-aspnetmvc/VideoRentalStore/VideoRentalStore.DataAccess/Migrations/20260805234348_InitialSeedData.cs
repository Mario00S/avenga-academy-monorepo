using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoRentalStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemainingFreeRentals = table.Column<int>(type: "int", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestriction", "Genre", "IsAvailable", "Language", "Length", "Quantity", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 16, 4, true, 0, new TimeSpan(0, 2, 16, 0, 0), 5, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 2, 13, 4, true, 0, new TimeSpan(0, 2, 28, 0, 0), 3, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 3, 12, 2, true, 0, new TimeSpan(0, 3, 15, 0, 0), 4, new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic" },
                    { 4, 18, 2, false, 0, new TimeSpan(0, 2, 55, 0, 0), 2, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 5, 13, 4, true, 0, new TimeSpan(0, 2, 49, 0, 0), 6, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 6, 13, 9, true, 0, new TimeSpan(0, 2, 32, 0, 0), 5, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 7, 18, 2, false, 0, new TimeSpan(0, 2, 34, 0, 0), 2, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 8, 13, 9, true, 0, new TimeSpan(0, 3, 1, 0, 0), 7, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Endgame" },
                    { 9, 16, 2, true, 7, new TimeSpan(0, 2, 12, 0, 0), 4, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parasite" },
                    { 10, 7, 6, true, 6, new TimeSpan(0, 2, 5, 0, 0), 5, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spirited Away" },
                    { 11, 18, 2, true, 0, new TimeSpan(0, 2, 19, 0, 0), 4, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { 12, 16, 2, true, 0, new TimeSpan(0, 2, 22, 0, 0), 6, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 13, 16, 9, false, 0, new TimeSpan(0, 2, 35, 0, 0), 3, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { 14, 7, 6, true, 0, new TimeSpan(0, 1, 28, 0, 0), 8, new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King" },
                    { 15, 12, 2, true, 0, new TimeSpan(0, 2, 8, 0, 0), 5, new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "La La Land" },
                    { 16, 18, 3, false, 0, new TimeSpan(0, 1, 58, 0, 0), 2, new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silence of the Lambs" },
                    { 17, 7, 6, true, 2, new TimeSpan(0, 1, 45, 0, 0), 7, new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { 18, 13, 2, true, 0, new TimeSpan(0, 2, 10, 0, 0), 4, new DateTime(2006, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Prestige" },
                    { 19, 12, 1, true, 3, new TimeSpan(0, 2, 2, 0, 0), 3, new DateTime(2001, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amélie" },
                    { 20, 16, 8, true, 2, new TimeSpan(0, 1, 58, 0, 0), 2, new DateTime(2006, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pan's Labyrinth" },
                    { 21, 12, 8, true, 0, new TimeSpan(0, 2, 58, 0, 0), 6, new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring" },
                    { 22, 12, 8, true, 0, new TimeSpan(0, 2, 59, 0, 0), 6, new DateTime(2002, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Two Towers" },
                    { 23, 12, 8, false, 0, new TimeSpan(0, 3, 21, 0, 0), 5, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { 24, 13, 9, true, 0, new TimeSpan(0, 2, 23, 0, 0), 7, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers" },
                    { 25, 13, 4, true, 0, new TimeSpan(0, 2, 1, 0, 0), 6, new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guardians of the Galaxy" },
                    { 26, 13, 9, true, 0, new TimeSpan(0, 2, 14, 0, 0), 8, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Panther" },
                    { 27, 18, 2, false, 0, new TimeSpan(0, 2, 2, 0, 0), 3, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joker" },
                    { 28, 13, 2, true, 0, new TimeSpan(0, 2, 0, 0, 0), 4, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Social Network" },
                    { 29, 12, 1, true, 0, new TimeSpan(0, 1, 39, 0, 0), 5, new DateTime(2014, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Grand Budapest Hotel" },
                    { 30, 16, 2, true, 0, new TimeSpan(0, 1, 46, 0, 0), 4, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiplash" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CardNumber", "CreatedOn", "FullName", "RemainingFreeRentals", "SubscriptionExpiresAt", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 25, "CARD001", new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", 3, null, 0 },
                    { 2, 32, "CARD002", new DateTime(2026, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Smith", 0, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 28, "CARD003", new DateTime(2026, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie Brown", 2, new DateTime(2026, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 30, "CARD004", new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana Prince", 1, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 35, "CARD005", new DateTime(2026, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan Hunt", 0, null, 0 },
                    { 6, 27, "CARD006", new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiona Gallagher", 2, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, 40, "CARD007", new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Miller", 3, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 22, "CARD008", new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hannah Baker", 1, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "Id", "MovieId", "Name", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Keanu Reeves", 0 },
                    { 2, 1, "Laurence Fishburne", 0 },
                    { 3, 1, "Carrie-Anne Moss", 0 },
                    { 4, 1, "Lana Wachowski", 1 },
                    { 5, 1, "Joel Silver", 2 },
                    { 6, 2, "Leonardo DiCaprio", 0 },
                    { 7, 2, "Joseph Gordon-Levitt", 0 },
                    { 8, 2, "Elliot Page", 0 },
                    { 9, 2, "Christopher Nolan", 1 },
                    { 10, 2, "Emma Thomas", 2 },
                    { 11, 3, "Leonardo DiCaprio", 0 },
                    { 12, 3, "Kate Winslet", 0 },
                    { 13, 3, "Billy Zane", 0 },
                    { 14, 3, "James Cameron", 1 },
                    { 15, 3, "Jon Landau", 2 },
                    { 16, 4, "Marlon Brando", 0 },
                    { 17, 4, "Al Pacino", 0 },
                    { 18, 4, "James Caan", 0 },
                    { 19, 4, "Francis Ford Coppola", 1 },
                    { 20, 4, "Albert S. Ruddy", 2 },
                    { 21, 5, "Matthew McConaughey", 0 },
                    { 22, 5, "Anne Hathaway", 0 },
                    { 23, 5, "Jessica Chastain", 0 },
                    { 24, 5, "Christopher Nolan", 1 },
                    { 25, 5, "Emma Thomas", 2 },
                    { 26, 6, "Christian Bale", 0 },
                    { 27, 6, "Heath Ledger", 0 },
                    { 28, 6, "Aaron Eckhart", 0 },
                    { 29, 6, "Christopher Nolan", 1 },
                    { 30, 6, "Charles Roven", 2 },
                    { 31, 7, "John Travolta", 0 },
                    { 32, 7, "Samuel L. Jackson", 0 },
                    { 33, 7, "Uma Thurman", 0 },
                    { 34, 7, "Quentin Tarantino", 1 },
                    { 35, 7, "Lawrence Bender", 2 },
                    { 36, 8, "Robert Downey Jr.", 0 },
                    { 37, 8, "Chris Evans", 0 },
                    { 38, 8, "Scarlett Johansson", 0 },
                    { 39, 8, "Anthony Russo", 1 },
                    { 40, 8, "Kevin Feige", 2 },
                    { 41, 9, "Song Kang-ho", 0 },
                    { 42, 9, "Cho Yeo-jeong", 0 },
                    { 43, 9, "Choi Woo-shik", 0 },
                    { 44, 9, "Bong Joon-ho", 1 },
                    { 45, 9, "Kwak Sin-ae", 2 },
                    { 46, 10, "Rumi Hiiragi", 0 },
                    { 47, 10, "Miyu Irino", 0 },
                    { 48, 10, "Mari Natsuki", 0 },
                    { 49, 10, "Hayao Miyazaki", 1 },
                    { 50, 10, "Toshio Suzuki", 2 },
                    { 51, 11, "Brad Pitt", 0 },
                    { 52, 11, "Edward Norton", 0 },
                    { 53, 11, "Helena Bonham Carter", 0 },
                    { 54, 11, "David Fincher", 1 },
                    { 55, 11, "Art Linson", 2 },
                    { 56, 12, "Tim Robbins", 0 },
                    { 57, 12, "Morgan Freeman", 0 },
                    { 58, 12, "Bob Gunton", 0 },
                    { 59, 12, "Frank Darabont", 1 },
                    { 60, 12, "Niki Marvin", 2 },
                    { 61, 13, "Russell Crowe", 0 },
                    { 62, 13, "Joaquin Phoenix", 0 },
                    { 63, 13, "Connie Nielsen", 0 },
                    { 64, 13, "Ridley Scott", 1 },
                    { 65, 13, "Douglas Wick", 2 },
                    { 66, 14, "Matthew Broderick", 0 },
                    { 67, 14, "James Earl Jones", 0 },
                    { 68, 14, "Jeremy Irons", 0 },
                    { 69, 14, "Roger Allers", 1 },
                    { 70, 14, "Don Hahn", 2 },
                    { 71, 15, "Ryan Gosling", 0 },
                    { 72, 15, "Emma Stone", 0 },
                    { 73, 15, "John Legend", 0 },
                    { 74, 15, "Damien Chazelle", 1 },
                    { 75, 15, "Fred Berger", 2 },
                    { 76, 16, "Jodie Foster", 0 },
                    { 77, 16, "Anthony Hopkins", 0 },
                    { 78, 16, "Scott Glenn", 0 },
                    { 79, 16, "Jonathan Demme", 1 },
                    { 80, 16, "Ron Bozman", 2 },
                    { 81, 17, "Anthony Gonzalez", 0 },
                    { 82, 17, "Gael García Bernal", 0 },
                    { 83, 17, "Benjamin Bratt", 0 },
                    { 84, 17, "Lee Unkrich", 1 },
                    { 85, 17, "Darla K. Anderson", 2 },
                    { 86, 18, "Hugh Jackman", 0 },
                    { 87, 18, "Christian Bale", 0 },
                    { 88, 18, "Scarlett Johansson", 0 },
                    { 89, 18, "Christopher Nolan", 1 },
                    { 90, 18, "Emma Thomas", 2 },
                    { 91, 19, "Audrey Tautou", 0 },
                    { 92, 19, "Mathieu Kassovitz", 0 },
                    { 93, 19, "Rufus", 0 },
                    { 94, 19, "Jean-Pierre Jeunet", 1 },
                    { 95, 19, "Claudie Ossard", 2 },
                    { 96, 20, "Ivana Baquero", 0 },
                    { 97, 20, "Sergi López", 0 },
                    { 98, 20, "Maribel Verdú", 0 },
                    { 99, 20, "Guillermo del Toro", 1 },
                    { 100, 20, "Álvaro Augustín", 2 },
                    { 101, 21, "Elijah Wood", 0 },
                    { 102, 21, "Ian McKellen", 0 },
                    { 103, 21, "Orlando Bloom", 0 },
                    { 104, 21, "Peter Jackson", 1 },
                    { 105, 21, "Barrie M. Osborne", 2 },
                    { 106, 22, "Sam Worthington", 0 },
                    { 107, 22, "Zoe Saldana", 0 },
                    { 108, 22, "Sigourney Weaver", 0 },
                    { 109, 22, "James Cameron", 1 },
                    { 110, 22, "Jon Landau", 2 },
                    { 111, 23, "Leonardo DiCaprio", 0 },
                    { 112, 23, "Matt Damon", 0 },
                    { 113, 23, "Jack Nicholson", 0 },
                    { 114, 23, "Martin Scorsese", 1 },
                    { 115, 23, "Brad Grey", 2 },
                    { 116, 24, "Joaquin Phoenix", 0 },
                    { 117, 24, "Robert De Niro", 0 },
                    { 118, 24, "Zazie Beetz", 0 },
                    { 119, 24, "Todd Phillips", 1 },
                    { 120, 24, "Emma Tillinger Koskoff", 2 },
                    { 121, 25, "Liam Neeson", 0 },
                    { 122, 25, "Ben Kingsley", 0 },
                    { 123, 25, "Ralph Fiennes", 0 },
                    { 124, 25, "Steven Spielberg", 1 },
                    { 125, 25, "Gerald R. Molen", 2 },
                    { 126, 26, "Tom Hanks", 0 },
                    { 127, 26, "Michael Clarke Duncan", 0 },
                    { 128, 26, "David Morse", 0 },
                    { 129, 26, "Frank Darabont", 1 },
                    { 130, 26, "David Valdes", 2 },
                    { 131, 27, "Mel Gibson", 0 },
                    { 132, 27, "Sophie Marceau", 0 },
                    { 133, 27, "Patrick McGoohan", 0 },
                    { 134, 27, "Mel Gibson", 1 },
                    { 135, 27, "Alan Ladd Jr.", 2 },
                    { 136, 28, "Ray Liotta", 0 },
                    { 137, 28, "Robert De Niro", 0 },
                    { 138, 28, "Joe Pesci", 0 },
                    { 139, 28, "Martin Scorsese", 1 },
                    { 140, 28, "Irwin Winkler", 2 },
                    { 141, 29, "Tom Hanks", 0 },
                    { 142, 29, "Robin Wright", 0 },
                    { 143, 29, "Gary Sinise", 0 },
                    { 144, 29, "Robert Zemeckis", 1 },
                    { 145, 29, "Wendy Finerman", 2 },
                    { 146, 30, "Jesse Eisenberg", 0 },
                    { 147, 30, "Andrew Garfield", 0 },
                    { 148, 30, "Justin Timberlake", 0 },
                    { 149, 30, "David Fincher", 1 },
                    { 150, 30, "Scott Rudin", 2 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "MovieId", "RentedOn", "ReturnedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, 3, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, 5, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 4, 6, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 5, 7, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 6, 8, new DateTime(2026, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 7, 9, new DateTime(2026, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 8, 10, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 9, 11, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 10, 19, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8 },
                    { 11, 20, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casts_MovieId",
                table: "Casts",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MovieId",
                table: "Rentals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
