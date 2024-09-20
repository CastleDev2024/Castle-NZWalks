using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDBContext _dBContext;

        public SQLWalkRepository(NZWalksDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Walk> Create(Walk walk)
        {
            await _dBContext.Walks.AddAsync(walk);
            await _dBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAll(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000)
        {
            //return await _dBContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            var walksDomain = _dBContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Apply filtering, if applicable
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = walksDomain.Where(x => x.Name.Contains(filterQuery));
                }
                if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = walksDomain.Where(x => x.Description.Contains(filterQuery));
                }
            }

            // Apply sorting, if applicable
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = isAscending ? walksDomain.OrderBy(x => x.Name) : walksDomain.OrderByDescending(x => x.Name);
                }
                if (sortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = isAscending ? walksDomain.OrderBy(x => x.Description) : walksDomain.OrderByDescending(x => x.Description);
                }
                if (sortBy.Equals("LengthInKM", StringComparison.OrdinalIgnoreCase))
                {
                    walksDomain = isAscending ? walksDomain.OrderBy(x => x.LengthInKm) : walksDomain.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await walksDomain.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByID(Guid id)
        {
            return await _dBContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> Update(Guid id, Walk walk)
        {
            var walkDomain = await _dBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDomain == null)
            {
                return null;
            }

            walkDomain.Name = walk.Name;
            walkDomain.Description = walk.Description;
            walkDomain.LengthInKm = walk.LengthInKm;
            walkDomain.WalkImageUrl = walk.WalkImageUrl;
            walkDomain.RegionId = walk.RegionId;
            walkDomain.DifficultyId = walk.DifficultyId;

            await _dBContext.SaveChangesAsync();

            return walkDomain;
        }

        public async Task<Walk?> Delete(Guid id)
        {
            var walkDomain = await _dBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDomain == null)
            {
                return null;
            }

            _dBContext.Walks.Remove(walkDomain);
            await _dBContext.SaveChangesAsync();

            return walkDomain;
        }
    }
}
