using FirstRestfulAPI.Model.Domain;

namespace FirstRestfulAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetRegionByID(Guid id);

        Task<Region> PostALLTEST2(Region region);

        Task<Region?> Update(Guid id, Region region);

        Task<Region?> DeleteRegionByID(Guid id);
    }
}
