using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        public readonly NZWalksDBContext _dBContext;

        public SQLRegionRepository(NZWalksDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _dBContext.Regions.AddAsync(region);
            await _dBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var regionDomain = await _dBContext.Regions.FindAsync(id);
            if (regionDomain == null)
            {
                return null;
            }

            _dBContext.Regions.Remove(regionDomain);
            await _dBContext.SaveChangesAsync();

            return regionDomain;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dBContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var regionDomain = await _dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return null;
            }

            regionDomain.Code = region.Code;
            regionDomain.Name = region.Name;
            regionDomain.RegionImageUrl = region.RegionImageUrl;

            await _dBContext.SaveChangesAsync();

            return region;
        }

    }
}
