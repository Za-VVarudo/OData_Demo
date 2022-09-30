using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OData_Demo.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    actor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    actor_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    age = table.Column<byte>(type: "tinyint", nullable: false),
                    average_movie_salary = table.Column<decimal>(type: "money", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.actor_id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genre_id = table.Column<byte>(type: "tinyint", nullable: false),
                    genre_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    movie_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    movie_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    genre = table.Column<byte>(type: "tinyint", nullable: false),
                    director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    amount_of_money = table.Column<decimal>(type: "money", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.movie_id);
                    table.ForeignKey(
                        name: "FK__Movie__genre__2C3393D0",
                        column: x => x.genre,
                        principalTable: "Genre",
                        principalColumn: "genre_id");
                });

            migrationBuilder.CreateTable(
                name: "ActedIn",
                columns: table => new
                {
                    actor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    movie_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActedIn", x => new { x.movie_id, x.actor_id });
                    table.ForeignKey(
                        name: "FK__ActedIn__actor_i__2A4B4B5E",
                        column: x => x.movie_id,
                        principalTable: "Actor",
                        principalColumn: "actor_id");
                    table.ForeignKey(
                        name: "FK__ActedIn__movie_i__2B3F6F97",
                        column: x => x.movie_id,
                        principalTable: "Movie",
                        principalColumn: "movie_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_genre",
                table: "Movie",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "UQ__Movie__CF729F9A323CC2F7",
                table: "Movie",
                column: "ImageLink",
                unique: true,
                filter: "[ImageLink] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActedIn");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
