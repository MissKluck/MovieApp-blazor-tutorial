using System;
using System.Collections.Generic;

namespace MovieApp.model;

public partial class Watchlist
{
    public string WatchlistID { get; set; } = null!;

    public int UserID { get; set; }

    public DateTime DateCreated { get; set; }
}
