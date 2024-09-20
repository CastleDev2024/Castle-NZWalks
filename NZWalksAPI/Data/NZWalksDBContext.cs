using Microsoft.EntityFrameworkCore;

using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("04bab3cb-2a9d-4c99-9644-23870a885b00"),
                    Name = "Easy"
,               },
                new Difficulty()
                {
                    Id = Guid.Parse("89cb3e26-d668-41d2-a177-04a3cb2f4db3"),
                    Name = "Medium"
,               },
                new Difficulty()
                {
                    Id = Guid.Parse("d31e5887-07a2-4494-aefb-837ef904e64d"),
                    Name = "Hard"
,               }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("0565d05f-6397-4d70-853b-fe4fbea1c712"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("78fc08c3-c4b0-4023-b8af-28b2bd7a0346"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("8fc1728e-1a44-4d99-a12a-642ad57fc0da"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("5d73d793-c52f-47f4-878a-0e89494341ec"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },                
                new Region()
                {
                    Id = Guid.Parse("853f7cb2-9815-462f-b434-baa1cc795f10"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("6bb31fa4-4bf2-4881-ac65-9f53c5d5a33d"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("883ea05d-befa-447f-9512-191ef201392c"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}
