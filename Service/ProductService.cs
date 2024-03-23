using DBService;
using Dto;
namespace Service
{
    public class ProductService
    {
        private readonly ProductDBService _productDbservice;

        public ProductService(ProductDBService productDbservice)
        {
            _productDbservice = productDbservice;
        }


//-------------------------------------- ADD PRODUCT ---------------------------------

        public async Task<bool> CreateProduct(CreateProductRequest createProductRequest)
        {
            return await _productDbservice.InsertProductWithSubscription(createProductRequest);

        }

//--------------------------------------- GET PRODUCT BY ID ------------------------------------

        public async Task<Product> GetProductById(string productId)
        {
            return await _productDbservice.GetProductById(productId);
        }


//--------------------------------------- GET ALL PRODUCTS -------------------------------------------


        public async Task<List<Product>> GetAllProducts()
        {
         
            return await _productDbservice.GetAllProducts();
        }

//-------------------------------------------- UPDATE PRODUCTS ------------------------------------------

        public async Task UpdateProduct(string productId, UpdateProductRequest updateProductRequest)
        {
             await _productDbservice.UpdateProductWithSubscription(productId,updateProductRequest);
        }

//------------------------------------------- DELETE PRODUCT ------------------------------------------------

        public async Task DeleteProduct(string productId)
        {
            await _productDbservice.DeleteProduct(productId);

        }


    }

}


