using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateComponentController : ControllerBase
    {
        private readonly UpdateComponentService _updateComponentService;
        
        public UpdateComponentController(UpdateComponentService updateComponentService)
        {
            _updateComponentService=updateComponentService;
           
        }
        
    [HttpPut("{ComponentID}")]
    public async Task<IActionResult> UpdateComponent(string componentID, [FromBody] UpdateComponentModel model)
    {
        try
        {
            await _updateComponentService.UpdateComponentAsync(componentID, model.FeatureID,model.Name,model.Code,model.UpdatedBy);
            return Ok("Component updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}