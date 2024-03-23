using Dto;

namespace Structure
{
    public interface IGetBundleandProduct
    {

        public  Task<GetBundle> GetBundleById(string bundleId);

        public Task<GetProduct> GetProductById(string productId);
        public  Task<List<GetBundle>> GetAllBundles();

        public Task<List<GetProduct>> GetAllProducts();






    }
}