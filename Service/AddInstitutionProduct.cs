using DBService;
using Dto;
using DTO;
using Structure;

namespace Service
{
 public class AddInstitutionProduct
 {
    private readonly AddInstituteProductDb _addInstitutionProduct;

    public AddInstitutionProduct(AddInstituteProductDb addInstitutionProduct)
    {
        _addInstitutionProduct=addInstitutionProduct; 
    }
    public async Task<int> InstitutionProductService(InstitutionProductModel model)
    {
       int result = await _addInstitutionProduct.AddInstituteProduct(model);
       return result;
    }
    public async Task<int> InstitutionProductDeletionService(string USRinstitutionID)
    {
       int result = await _addInstitutionProduct.DeleteInstitutionProductAsync(USRinstitutionID);
       return result;
    }
    public async Task<int> InstitutionProductUpdationService(string InstituteProductID,UpdateInstitutionProductModel model)
    {
       int result = await _addInstitutionProduct.UpdateInstituteProduct(InstituteProductID, model);
       return result;
    }
    public async Task<List<InstitutionProductModelForGetAll>> GetAllInstituteProductService()
    {
        List<InstitutionProductModelForGetAll> lst = await _addInstitutionProduct.GetAllInstituteProductsAsync();
        return lst;
    }


    }
}