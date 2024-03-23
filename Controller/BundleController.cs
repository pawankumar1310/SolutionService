using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller 
{
    [ApiController]
    [Route("api/[controller]")]
    public class BundleController : ControllerBase
    {
        private readonly BundleService _bundleService;

        public BundleController(BundleService bundleService)
        {
            _bundleService = bundleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBundle([FromBody] BundleCreationRequest bundleRequest)
        {
            try
            {
                var bundleId = await _bundleService.CreateBundle(bundleRequest);
                if(bundleId)
                {
                    return Ok("Bundle Added Successfully..");
                }
                else
                {
                    return Ok("Failed to Add Bundle..");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{bundleId}")]
        public async Task<IActionResult> GetBundleById(string bundleId)
        {
            //try
            //{
                var bundle = await _bundleService.GetBundleById(bundleId);

                //if (bundle != null)
                //{
                   

                    return Ok(bundle);
            //    }
            //    else
            //    {
            //        return NotFound("Bundle not found");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception or handle it appropriately

            //    return StatusCode(500, "Internal Server Error");
            //}
        }

        [HttpGet("getAllBundles")]
        public async Task<IActionResult> GetAllBundles()
        {
            //try
            //{
                var bundles = await _bundleService.GetAllBundlesAsync();
                //if(bundles != null)
                //{
                    return Ok(bundles);
            //    }
            //    else
            //    {
            //        return Ok("Bundles not found");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    return StatusCode(500, "Internal Server Error");
            //}

        }

        [HttpPut("{bundleId}")]
        public async Task<IActionResult> UpdateBundle(string bundleId, [FromBody] BundleUpdateRequest bundleRequest)
        {
            try
            {
                await _bundleService.UpdateBundle(bundleId, bundleRequest);
                return Ok(new { Message = "Bundle updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{bundleId}")]
        public async Task<IActionResult> DeleteBundle(string bundleId)
        {
            try
            {
                await _bundleService.DeleteBundle(bundleId);
                return Ok(new { Message = "Bundle deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}