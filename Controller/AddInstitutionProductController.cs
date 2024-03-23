using Dto;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddInstitutionProductController : ControllerBase
    {
        private readonly AddInstitutionProduct _addInstituteProduct;
        
        public AddInstitutionProductController(AddInstitutionProduct addInstituteProduct)
        {
            _addInstituteProduct = addInstituteProduct;
           
        }

        [HttpPost("ProductSubscription")]
        public async Task<IActionResult> InsertInstitutionProduct([FromBody] InstitutionProductModel model)
        {
            try
            {
                int rowsAffected = await _addInstituteProduct.InstitutionProductService(model);

                if (rowsAffected > 0)
                {
                    return Ok($"Institution product Added Succesfully.");
                }
                else
                {
                    return BadRequest($"Failed to add product.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("InstitutionProduct")]
        public async Task<IActionResult> DeleteInstitutionProduct(string USRinstitutionID)
        {
            try
            {
                int result=await _addInstituteProduct.InstitutionProductDeletionService(USRinstitutionID);
                if (result > 0)
                {
                    return Ok("InstitutionProduct deleted successfully.");
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("InstituteProductID")]
        public async Task<IActionResult> UpdateInstitutionProduct(string institutionProductID, [FromBody] UpdateInstitutionProductModel model)
        {
            try
            {
                await _addInstituteProduct.InstitutionProductUpdationService(institutionProductID, model);
                return Ok("InstitutionProduct  updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstituteProduct()
        {
            try
            {
                List<InstitutionProductModelForGetAll> institutionProductModelForGetAlls = await _addInstituteProduct.GetAllInstituteProductService();
                return Ok(institutionProductModelForGetAlls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}