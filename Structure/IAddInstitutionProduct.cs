using DTO;

namespace Structure
{
    public interface IAddInstitutionProduct
    {
        public Task<int> AddInstituteProduct(InstitutionProductModel model);
    }
}