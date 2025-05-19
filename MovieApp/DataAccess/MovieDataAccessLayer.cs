using Microsoft.EntityFrameworkCore;
using MovieApp.Interfaces;
using MovieApp.model;

namespace MovieApp.DataAccess;

public class MovieDataAccessLayer : IMovie
{
    readonly MovieDbContext _dbContext;

    public MovieDataAccessLayer(IDbContextFactory<MovieDbContext> dbContext)
    {
        _dbContext = dbContext.CreateDbContext();
    }
    public async Task<List<Genre>> GetGenre()
    {
        return await _dbContext.Genres.AsNoTracking().ToListAsync();
    }

    // Add method that accepts the movie object as parameter and adds it to the Movies DB set. Then database is updated by invoking the SaveChangesAsync method
    public async Task AddMovie(Movie movie)
    {
        try
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }
}
