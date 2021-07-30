using back_end.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_end
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>()
                .HasKey(x => new { x.ActorId, x.MovieId });

            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new { x.MovieId, x.GenreId });



            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action"},
                new Genre { Id = 2, Name = "Adventure"},
                new Genre { Id = 3, Name = "Comedy"});
  
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Sam Worthington", Biography="", Photo=""},
                new Actor { Id = 2, Name = "Tobey Maguire", Biography="", Photo=""},
                new Actor { Id = 3, Name = "Kirsten Dunst", Biography="", Photo=""});

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Avatar", 
                Summary="A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.", Poster="https://m.media-amazon.com/images/I/41kTVLeW1CL._AC_SY450_.jpg"},
                new Movie { Id = 2, Title = "Spider Man", 
                Summary="A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.", Poster="https://m.media-amazon.com/images/I/51MssEjdaRL._AC_.jpg"});


            modelBuilder.Entity<MoviesGenres>().HasData(
                new MoviesGenres { MovieId = 1, GenreId = 1},
                new MoviesGenres { MovieId = 2, GenreId = 1},
                new MoviesGenres { MovieId = 2, GenreId = 2});
           
           modelBuilder.Entity<MoviesActors>().HasData(
                new MoviesActors { MovieId = 1, ActorId = 1, Character="Jake Sully"},
                new MoviesActors { MovieId = 2, ActorId = 1, Character="Spider Man"},
                new MoviesActors { MovieId = 2, ActorId = 3, Character="Mary Jane Watson"});
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }

    }
}