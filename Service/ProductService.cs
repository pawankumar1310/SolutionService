//using DBService;
//using Dto;
//using DTO.SolutionService;
//using Model.SolutionService;
//using Shared.DTO.Package;
//namespace Service
//{
//    public class ProductService
//    {
//        public StatusResponse<int> AddProductWithSubscription(AddProductSubscriptionRequest addProductSubscriptionRequest)
//        {
//            try
//            {
//                ProductDBService productDBService = new();
//                var AddProductModel = new AddProductSubscriptionModel
//                {
//                    Name = addProductSubscriptionRequest.Name,
//                    Code = addProductSubscriptionRequest.Code,
//                    AmountPerDay = addProductSubscriptionRequest.AmountPerDay,
//                    SubscriptionModes = addProductSubscriptionRequest.SubscriptionModes,
//                    CreatedBy = addProductSubscriptionRequest.CreatedBy,
//                };
//                var result = productDBService.AddProductWithSubscription(AddProductModel).Result;
//                if(result.Success)
//                {
//                    return StatusResponse<int>.SuccessStatus(result.Data, StatusCode.Success);
//                }
//                else
//                {
//                    return StatusResponse<int>.FailureStatus(result.StatusCode, new Exception());
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public StatusResponse<List<GetProductRequest>> GetInstitutionProductById(ProductIDRequest productIDRequest)
//        {
//            try
//            {
//                ProductDBService productDBService = new();
//                var GetProductRequestModel = new ProductIDModel
//                { 
//                    ProductId = productIDRequest.ProductId,

//                };
//                var result = productDBService.GetInstitutionProductById(GetProductRequestModel).Result;
//                if(result.Success)
//                {
//                    List<GetProductRequest> getProductRequests = new();
//                    foreach(var product in result.Data)
//                    {
//                        getProductRequests.Add(new GetProductRequest() 
//                        { 
//                            ProductID = product.ProductID,
//                            Name = product.Name,
//                            Code = product.Code,
//                            AmountPerDay = product.AmountPerDay,
//                            SubscriptionModes = product.SubscriptionModes,
//                            CreatedBy = product.CreatedBy,
//                            CreatedDate = product.CreatedDate,
//                            SubscriptionIds = product.SubscriptionIds,
//                            UpdatedBy = product.UpdatedBy,
//                            UpdatedDate = product.UpdatedDate,
//                        });

//                    }
//                    return StatusResponse<List<GetProductRequest>>.SuccessStatus(getProductRequests, StatusCode.Found);
//                }
//                else
//                {
//                    return StatusResponse<List<GetProductRequest>>.FailureStatus(result.StatusCode, new Exception());
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<List<GetProductRequest>>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
        
//    }
        

//}


