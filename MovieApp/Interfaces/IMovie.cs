using MovieApp.model;

namespace MovieApp.Interfaces;

public interface IMovie
{
    Task<List<Genre>> GetGenre();

    Task AddMovie(Movie movie);
}