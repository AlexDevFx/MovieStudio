using Microsoft.EntityFrameworkCore;
using MovieStudio.Core.Movies;
using MovieStudio.Core.Users;
using MovieStudio.Data.Configurations;

namespace MovieStudio.Data;

public partial class MoviesDbContext: DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieOffer> Offers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MoviesConfiguration());
        modelBuilder.ApplyConfiguration(new OffersConfiguration());
        modelBuilder.ApplyConfiguration(new GenresConfiguration());
        modelBuilder.ApplyConfiguration(new MovieGenresConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorsConfiguration());
        modelBuilder.ApplyConfiguration(new ActorsConfiguration());
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public MoviesDbContext(DbContextOptions options) : base(options)
    {
    }
}