using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Audi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Renault')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Skoda')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Volkswagen')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A3', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A5', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A6', (SELECT ID FROM Makes WHERE Name = 'Audi'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Series 1', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Series 2', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Series 3', (SELECT ID FROM Makes WHERE Name = 'BMW'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Fleunce', (SELECT ID FROM Makes WHERE Name = 'Renault'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Kadjar', (SELECT ID FROM Makes WHERE Name = 'Renault'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Megan', (SELECT ID FROM Makes WHERE Name = 'Renault'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Kodiac', (SELECT ID FROM Makes WHERE Name = 'Skoda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Ocatvia', (SELECT ID FROM Makes WHERE Name = 'Skoda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Superb', (SELECT ID FROM Makes WHERE Name = 'Skoda'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Golf', (SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Passat', (SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Tiguan', (SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
