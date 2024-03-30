//using DTO.SolutionService;
//using Microsoft.AspNetCore.Mvc;
//using Service;

//namespace Controller
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        [HttpPost("AddProductWithSubscription")]
//        public IActionResult AddProductWithSubscription(AddProductSubscriptionRequest addProductSubscriptionRequest)
//        {
//            if(!string.IsNullOrEmpty(addProductSubscriptionRequest.Name) || !string.IsNullOrEmpty(addProductSubscriptionRequest.CreatedBy) || !string.IsNullOrEmpty(addProductSubscriptionRequest.Code) || addProductSubscriptionRequest.SubscriptionModes!=null || addProductSubscriptionRequest.AmountPerDay!=null )
//            {
//                try
//                {
//                    ProductService productService = new();
//                    return Ok(productService.AddProductWithSubscription(addProductSubscriptionRequest));
//                }
//                catch
//                {
//                    return StatusCode(500);
//                }
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//        [HttpPost("GetInstitutionProductById")]
//        public IActionResult GetInstitutionProductById(ProductIDRequest getProductID)
//        {
//            if (!string.IsNullOrEmpty(getProductID.ProductId))
//            {
//                try
//                {
//                    ProductService productService = new();
//                    return Ok(productService.GetInstitutionProductById(getProductID));
//                }
//                catch
//                {
//                    return StatusCode(500);
//                }

//            }
//            else
//            {
//                return BadRequest();
//            }

//        }
//    }
//}
