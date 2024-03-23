using DBService;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly FeatureDBService _featureDBService;

        public FeatureController(FeatureDBService featureDBService)
        {
            _featureDBService = featureDBService;

        }

        [HttpGet]
        
        public async Task<IActionResult> GetFeatureCode(string userId)
        {
            try
            {
                List<string> featureCodes = await _featureDBService.GetFeatureCodeByUserId(userId);

                if (featureCodes.Count > 0)
                {
                    return Ok(featureCodes);
                }
                else
                {
                    return NotFound(); // User not found or no associated feature codes
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
