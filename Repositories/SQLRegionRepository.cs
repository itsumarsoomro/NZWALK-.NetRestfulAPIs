using FirstRestfulAPI.Data;
using FirstRestfulAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace FirstRestfulAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

      

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByID(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Region> PostALLTEST2(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> Update(Guid id, Region region)
        {
            var existingREgion = await dbContext.Regions.FirstOrDefaultAsync(x =>x.id == id);

            if (existingREgion != null)
            {
              existingREgion.Code = region.Code;
              existingREgion.Name = region.Name;
              existingREgion.RegionImageUrl = region.RegionImageUrl;


              await dbContext.SaveChangesAsync();

             return region;
            }

            return null;
        }

        public async Task<Region?> DeleteRegionByID(Guid id)
        {
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(y => y.id == id);

            if (regionDomain == null)
            {
                return null;
            }

            dbContext.Regions.Remove(regionDomain);
            await dbContext.SaveChangesAsync();

            return regionDomain;
        }
    }
}
