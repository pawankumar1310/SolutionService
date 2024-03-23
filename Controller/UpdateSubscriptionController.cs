using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSubscriptionController : ControllerBase
    {
        private readonly UpdateSubscriptionService _updateSubscriptionService;
        
        public UpdateSubscriptionController(UpdateSubscriptionService updateSubscriptionService)
        {
            _updateSubscriptionService=updateSubscriptionService;
           
        }
        
    [HttpPut("{subscriptionID}")]
    public async Task<IActionResult> UpdateSubscription(string subscriptionID, [FromBody] UpdateSubscriptionModel model)
    {
        try
        {
            await _updateSubscriptionService.UpdateSubscriptionAsync(subscriptionID, model.Mode, model.MaximumDays, model.MinimumDays, model.UpdatedBy);
            return Ok("Subscription updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}