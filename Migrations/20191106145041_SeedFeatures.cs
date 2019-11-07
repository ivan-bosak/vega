using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hatchback')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Sedan')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Crossover')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Coupe')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features");
        }
    }
}
