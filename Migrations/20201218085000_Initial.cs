using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelId = table.Column<int>(nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 255, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    VehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeatures",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeatures", x => new { x.FeatureId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_VehicleId",
                table: "Photos",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_VehicleId",
                table: "VehicleFeatures",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

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
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hatchback')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Sedan')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Crossover')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Coupe')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "VehicleFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
            
            
            migrationBuilder.Sql("DELETE FROM Makes");
            migrationBuilder.Sql("DELETE FROM Features");
        }
    }
}
