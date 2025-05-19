using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genreid = table.Column<int>(type: "integer", nullable: false),
                    genrename = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_pkey", x => x.genreid);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    overview = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    genre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    language = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: true),
                    posterpath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("movie_pkey", x => x.movieid);
                });

            migrationBuilder.CreateTable(
                name: "usermaster",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    lastname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    gender = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    usertypename = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usermaster_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "usertype",
                columns: table => new
                {
                    usertypeid = table.Column<int>(type: "integer", nullable: false),
                    usertypename = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usertype_pkey", x => x.usertypeid);
                });

            migrationBuilder.CreateTable(
                name: "watchlist",
                columns: table => new
                {
                    watchlistid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    datecreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("watchlist_pkey", x => x.watchlistid);
                });

            migrationBuilder.CreateTable(
                name: "watchlistitems",
                columns: table => new
                {
                    watchlistitemid = table.Column<int>(type: "integer", nullable: false),
                    watchlistid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    movieid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("watchlistitems_pkey", x => x.watchlistitemid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "usermaster");

            migrationBuilder.DropTable(
                name: "usertype");

            migrationBuilder.DropTable(
                name: "watchlist");

            migrationBuilder.DropTable(
                name: "watchlistitems");
        }
    }
}
