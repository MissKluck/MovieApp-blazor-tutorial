using System;
using System.Collections.Generic;

namespace MovieApp.model;

public partial class WatchlistItems
{
    public int WatchlistItemID { get; set; }

    public string WatchlistID { get; set; } = null!;

    public int MovieID { get; set; }
}
