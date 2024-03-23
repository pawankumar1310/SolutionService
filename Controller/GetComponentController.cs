using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetComponentController : ControllerBase
    {
        private readonly GetComponentService _getComponentService;
        
        public GetComponentController(GetComponentService getComponentService)
        {
            _getComponentService=getComponentService;
           
        }
        
    [HttpGet]
    public async Task<IActionResult> GetAllComponents()
    {
        try
        {
            List<GetComponentModel> Components = await _getComponentService.GetAllComponentsAsync();
            return Ok(Components);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}