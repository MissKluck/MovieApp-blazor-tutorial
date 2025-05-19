using System;
using System.Collections.Generic;

namespace MovieApp.model;

public partial class Usermaster
{
    public int UserID { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string UserTypeName { get; set; } = null!;
}
