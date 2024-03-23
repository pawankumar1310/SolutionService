using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteComponentController : ControllerBase
    {
        private readonly DeleteComponentService _deleteComponentService;
        
        public DeleteComponentController(DeleteComponentService deleteComponentService)
        {
            _deleteComponentService=deleteComponentService;
           
        }
        
    [HttpDelete("{ComponentID}")]
    public async Task<IActionResult> DeleteComponent(string ComponentID)
    {
        try
        {
            await _deleteComponentService.DeleteComponentServiceAsync(ComponentID);
            return Ok("Component deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}