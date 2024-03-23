using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class BundleAndProductController : ControllerBase
    {
        private readonly GetBundleandProductService _bundleAndProductService;

        public BundleAndProductController(GetBundleandProductService bundleAndProductService)
        {
            _bundleAndProductService = bundleAndProductService;
        }

        [HttpGet("getBundleWithProductsById/{bundleId}")]
        public async Task<IActionResult> GetBundleById(string bundleId)
        {
            try
            {
                GetBundle bundle = await _bundleAndProductService.GetBundleById(bundleId);

                if (bundle == null)
                {
                    return NotFound($"Bundle with ID {bundleId} not found.");
                }

                return Ok(bundle);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getAllBundleswithProducts")]
        public async Task<IActionResult> GetAllBundles()
        {
            try
            {
                List<GetBundle> bundles = await _bundleAndProductService.GetAllBundles();
                return Ok(bundles);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getProductWithSubscriptionsById/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            try
            {
                GetProduct product = await _bundleAndProductService.GetProductById(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getAllProductsWithSubscriptions")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<GetProduct> products = await _bundleAndProductService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}