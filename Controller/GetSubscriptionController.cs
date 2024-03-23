using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSubscriptionController : ControllerBase
    {
        private readonly GetSubscriptionService _getsubscriptionService;
        
        public GetSubscriptionController(GetSubscriptionService getSubscriptionService)
        {
            _getsubscriptionService=getSubscriptionService;
           
        }
        
    [HttpGet]
    public async Task<IActionResult> GetAllSubscription()
    {
        try
        {
            List<GetSubscriptionModel> subscription = await _getsubscriptionService.GetAllSubscriptionAsync();
            return Ok(subscription);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{subscriptionID}")]
    public async Task<IActionResult> GetSubscriptionByID(string subscriptionID)
    {
        try
        {
            var subscription = await _getsubscriptionService.GetSubscriptionByIDAsync(subscriptionID);
            return Ok(subscription);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    }
}