using MovieApp.Interfaces;
using MovieApp.model;

namespace MovieApp.GraphQL;

public class MovieQueryResolver
{
    readonly IMovie _movieService;

    public MovieQueryResolver(IMovie movieService)
    {
        _movieService = movieService;
    }

    [GraphQLName("genreList")]
    public async Task<List<Genre>> GetGenreList()
    {
        return await _movieService.GetGenre();
    }
}
