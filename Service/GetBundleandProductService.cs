using DBService;
using Dto;
namespace Service
{
    public class GetBundleandProductService
    {
        private readonly GetBundlesAndProductsDBService _getBundlesAndProductsDBService;

        public GetBundleandProductService(GetBundlesAndProductsDBService getBundlesAndProductsDBService)
        {
            _getBundlesAndProductsDBService = getBundlesAndProductsDBService;
        }

        public  async Task<GetBundle> GetBundleById(string bundleId)
        {
            return await _getBundlesAndProductsDBService.GetBundleById(bundleId);
        }


        public async Task<List<GetBundle>> GetAllBundles()
        {
            return await _getBundlesAndProductsDBService.GetAllBundles();
        }


        public async Task<GetProduct> GetProductById(string productId)
        {
            return await _getBundlesAndProductsDBService.GetProductById(productId);
        }


        public async Task<List<GetProduct>> GetAllProducts()
        {
            return await _getBundlesAndProductsDBService.GetAllProducts();
        }

    }
}
