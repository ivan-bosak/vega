using Microsoft.EntityFrameworkCore;
using vega.Core.Models;

namespace vega.Persistence
{
    public class VegaDbContext: DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options)
        : base( options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed makes
            modelBuilder.Entity<Make>().HasData(new Make { Id = 1, Name = "Audi" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 2, Name = "BMW" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 3, Name = "Reanult" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 4, Name = "Skoda" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 5, Name = "Volkswagen" });

            //seed models
            modelBuilder.Entity<Model>().HasData(new Model { Id = 1, Name = "A3", MakeId = 1 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 2, Name = "A4", MakeId = 1 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 3, Name = "A6", MakeId = 1 });

            modelBuilder.Entity<Model>().HasData(new Model { Id = 5, Name = "Series 1", MakeId = 2 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 6, Name = "Series 2", MakeId = 2 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 7, Name = "Series 3", MakeId = 2 });
 
            modelBuilder.Entity<Model>().HasData(new Model { Id = 8, Name = "Fleunce", MakeId = 3 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 9, Name = "Kadjar", MakeId = 3 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 10, Name = "Megan", MakeId = 3 });

            modelBuilder.Entity<Model>().HasData(new Model { Id = 11, Name = "Kodiac", MakeId = 4 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 12, Name = "Ocatvia", MakeId = 4 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 13, Name = "Superb", MakeId = 4 });

            modelBuilder.Entity<Model>().HasData(new Model { Id = 14, Name = "Golf", MakeId = 5 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 15, Name = "Passat", MakeId = 5 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 16, Name = "Tiguan", MakeId = 5 });
            
            //seed features
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 1, Name = "Air conditioner"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 2, Name = "Airbag"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 3, Name = "ABS"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 4, Name = "ESP"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 5, Name = "Cruise control"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 6, Name = "Navigation system"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 7, Name = "Traction control"});
            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 8, Name = "Tyre pressure monitoring"});

            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
            new {vf.FeatureId, vf.VehicleId});
        }
    }
}