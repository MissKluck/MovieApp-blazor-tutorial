using MovieApp.Interfaces;
using MovieApp.model;

namespace MovieApp.Server.GraphQL
{
    public class MovieMutationResolver
    {
        public record AddMoviePayload(Movie movie);

        readonly IWebHostEnvironment _hostingEnvironment;
        readonly IMovie _movieService;
        readonly IConfiguration _config;
        readonly string posterFolderPath = string.Empty;

        public MovieMutationResolver(IConfiguration config, IMovie movieService, IWebHostEnvironment hostingEnvironment)
        {
            _config = config;
            _movieService = movieService;
            _hostingEnvironment = hostingEnvironment;
            posterFolderPath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "Poster");
        }

        [GraphQLDescription("Add new movie data.")]
        public AddMoviePayload AddMovie(Movie movie)
        {
            if (!string.IsNullOrEmpty(movie.PosterPath))
            {
                //If the user has uploaded a      poster while adding movie data, create a poster name using a GUID
                string fileName = Guid.NewGuid() + ".jpg";
                string fullPath = System.IO.Path.Combine(posterFolderPath, fileName);

                // converts the poster data to a byte array and then saves it as a file in the Poster folder
                byte[] imageBytes = Convert.FromBase64String(movie.PosterPath);
                File.WriteAllBytes(fullPath, imageBytes);

                movie.PosterPath = fileName;
            }
            else
            {
                //if user has not uploaded any image, use the default poster path
                movie.PosterPath = _config["DefaultPoster"];
            }

            _movieService.AddMovie(movie);

            return new AddMoviePayload(movie);
        }
    }
}