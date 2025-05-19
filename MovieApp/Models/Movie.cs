using System;
using System.Collections.Generic;

namespace MovieApp.model;

public partial class Movie
{
    public int MovieID { get; set; }

    public string Title { get; set; } = null!;

    public string Overview { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int Duration { get; set; }

    public decimal? Rating { get; set; }

    public string? Posterpath { get; set; }
}
