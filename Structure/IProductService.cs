using Dto;

namespace Structure
{
    public interface IProductService
    {
        Task<bool> InsertProductWithSubscription(CreateProductRequest productRequest);
    }
}