using FirstRestfulAPI.Model.Domain;
using System.Runtime.InteropServices;

namespace FirstRestfulAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, int PageNumber = 1, int PageSize = 1000);

        Task<Walk?> GetByIDAsync(Guid id);

        Task<Walk> UpdateAsync(Guid id, Walk walk);
        
        Task<Walk?> DeleteAsync(Guid id);
    }
}
