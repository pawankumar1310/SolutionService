using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Dto;

namespace Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var productId = await _productService.CreateProduct(request);
                return Ok("Product added Successfully..");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getProductById/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            // try
            // {
                var product = await _productService.GetProductById(productId);
                return Ok(product);
            // }
            // catch (Exception ex)
            // {
            //     // Log the exception or handle it appropriately
            //     return StatusCode(500, "Internal Server Error");
            // }
        }


        
        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            // try
            // {
                var products = await _productService.GetAllProducts();
                // if(products != null)
                // {
                    return Ok(products);
            //     }
            //     else
            //     {
            //         return Ok("Products not found");
            //     }
            // }
            // catch(Exception ex)
            // {
            //     return StatusCode(500, "Internal Server Error");
            // }

        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, [FromBody] UpdateProductRequest request)
        {
            try
            {
                await _productService.UpdateProduct(productId, request);
               return Ok();
            }   
            catch (Exception ex)
            {
               // Log the exception or handle it appropriately
               return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("deleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            try
            {
                await _productService.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}