using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSubscriptionController : ControllerBase
    {
        private readonly AddSubscriptionService _addSubscriptionService;
        
        public AddSubscriptionController(AddSubscriptionService addSubscriptionService)
        {
            _addSubscriptionService=addSubscriptionService;
           
        }
        
    [HttpPost]
    public async Task<IActionResult> AddSubscription([FromBody] AddSubscriptionModel model)
    {
        try
        {
            await _addSubscriptionService.AddSubscriptionServiceAsync(model.Mode, model.CreatedBy, model.MaximumDays, model.MinimumDays);
            return Ok("Subscription added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}