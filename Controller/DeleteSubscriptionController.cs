using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteSubscriptionController : ControllerBase
    {
        private readonly DeleteSubscriptionService _deleteSubscriptionService;
        
        public DeleteSubscriptionController(DeleteSubscriptionService deleteSubscriptionService)
        {
            _deleteSubscriptionService=deleteSubscriptionService;
           
        }
        
    [HttpDelete("{SubscriptionId}")]
    public async Task<IActionResult> DeleteSubscription(string SubscriptionId)
    {
        try
        {
            await _deleteSubscriptionService.DeleteSubscriptionServiceAsync(SubscriptionId);
            return Ok("Subscription deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}