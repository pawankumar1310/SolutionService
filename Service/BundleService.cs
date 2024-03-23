using DBService;
using Dto;
namespace Service
{
    public class BundleService
    {
        private readonly BundleDBService _bundleDbservice;

        public BundleService(BundleDBService bundleDbservice)
        {
            _bundleDbservice = bundleDbservice;
        }

        // Create a new bundle
        public async Task<bool> CreateBundle(BundleCreationRequest bundleCreationRequest)
        {
            
            return await _bundleDbservice.InsertBundleWithProducts(bundleCreationRequest);
        }

        // Read a bundle by ID
        public async Task<Bundle> GetBundleById(string bundleId)
        {
            
            return await _bundleDbservice.GetBundleById(bundleId);
        }

        //Read all bundles
        public async Task<List<Bundle>> GetAllBundlesAsync()
        {
            return await _bundleDbservice.GetAllBundles();
        }

        // Update a bundle
        public async Task UpdateBundle(string bundleId, BundleUpdateRequest bundleUpdateRequest)
        {
            
            await _bundleDbservice.UpdateBundleWithProducts(bundleId,bundleUpdateRequest);
        }

        // Delete a bundle by ID
        public async Task DeleteBundle(string bundleId)
        {
            
            await _bundleDbservice.DeleteBundle(bundleId);
        }
    }

}