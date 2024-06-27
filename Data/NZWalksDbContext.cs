using FirstRestfulAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace FirstRestfulAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        //will understand more in dept with chatgpt
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
        
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficultoies
            //easy medium and hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("e40053c1-b804-4c40-95c1-8fc321291e8e"),
                    Name = "Easy"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("f6aea21c-22c4-4da7-bbdb-46a36f230115"),
                    Name = "Medium"
                }
                ,
                    new Difficulty()
                {
                    Id = Guid.Parse("b9c2ce9d-f7c6-4a15-9436-9c8a8318777a"),
                    Name = "Hard"
                }
            };

            //seed diffficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    id = Guid.Parse($"{Guid.NewGuid().ToString()}"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "img.jpg"
                },
                new Region() {
                    id = Guid.Parse($"{Guid.NewGuid().ToString()}"),
                    Name = "Bangladesh",
                    Code = "BNG",
                    RegionImageUrl = "img.jpg"
                },
                new Region() {
                    id = Guid.Parse($"{Guid.NewGuid().ToString()}"),
                    Name = "Pakistan",
                    Code = "PAK",
                    RegionImageUrl = "img.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
