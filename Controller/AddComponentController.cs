using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddComponentController : ControllerBase
    {
        private readonly AddComponentService _addComponentService;
        
        public AddComponentController(AddComponentService addComponentService)
        {
            _addComponentService=addComponentService;
           
        }
        
    [HttpPost]
    public async Task<IActionResult> AddComponent([FromBody] AddComponentModel model)
    {
        try
        {
            await _addComponentService.AddComponentServiceAsync(model.FeatureID, model.Name, model.Code, model.CreatedBy);
            return Ok("Component added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}