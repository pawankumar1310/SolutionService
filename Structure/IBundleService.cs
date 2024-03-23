using Dto;

namespace Structure
{
    public interface IBundleService
    {
        Task<bool> InsertBundleWithProducts(BundleCreationRequest bundleCreationRequest);
        Task<Bundle> GetBundleById(string bundleId);
        Task<List<Bundle>> GetAllBundles();
        Task UpdateBundleWithProducts(string bundleID, BundleUpdateRequest bundleUpdateRequest);
        Task DeleteBundle(string bundleId);
    }

}