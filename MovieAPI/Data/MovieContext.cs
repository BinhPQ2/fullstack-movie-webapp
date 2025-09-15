using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;

namespace MovieAPI.Data
{

    public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        // Method to send data into database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                            new Genre { Id = 1, Name = "Action" },
                            new Genre { Id = 2, Name = "Sci-Fi" },
                            new Genre { Id = 3, Name = "Fantasy" },
                            new Genre { Id = 4, Name = "Horror" },
                            new Genre { Id = 5, Name = "Romance" }
                        );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Inception",
                    Price = 9.99M, // Need M suffix for decimal literals
                    GenreId = 1,
                    ReleaseDate = new DateOnly(2010, 07, 16)
                },
                new Movie
                {
                    Id = 2,
                    Name = "The Dark Knight",
                    Price = 8.99M,
                    GenreId = 1,
                    ReleaseDate = new DateOnly(2008, 07, 18)
                },
                new Movie
                {
                    Id = 3,
                    Name = "Forrest Gump",
                    Price = 7.99M,
                    GenreId = 3,
                    ReleaseDate = new DateOnly(1994, 07, 06)
                },
                new Movie
                {
                    Id = 4,
                    Name = "The Matrix",
                    Price = 9.49M,
                    GenreId = 2,
                    ReleaseDate = new DateOnly(1999, 03, 31)
                },
                new Movie
                {
                    Id = 5,
                    Name = "Interstellar",
                    Price = 10.99M,
                    GenreId = 2,
                    ReleaseDate = new DateOnly(2014, 11, 07)
                },
                new Movie
                {
                    Id = 6,
                    Name = "The Conjuring",
                    Price = 6.99M,
                    GenreId = 4,
                    ReleaseDate = new DateOnly(2013, 07, 19)
                }
            );
        }
    }
}