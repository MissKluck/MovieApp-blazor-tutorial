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
}
