using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAll(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);

        Task<Walk?> GetByID(Guid id);

        Task<Walk> Create(Walk walk);

        Task<Walk?> Update(Guid id, Walk walk);

        Task<Walk?> Delete(Guid id);

    }
}
