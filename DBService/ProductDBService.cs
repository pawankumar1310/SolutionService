//using Model.SolutionService;
//using System.Data.SqlClient;
//using System.Globalization;
//using System.Reflection;
//using System.Data;

//namespace DBService
//{
//    public class ProductDBService
//    {
//        public string connectionString = Utility.ConfigurationUtility.GetConnectionString();
//        public async Task<StatusResponse<int>> AddProductWithSubscription(AddProductSubscriptionModel productSubscriptionModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var storedProcedure = SolutionDB.AddProductWithSubscription;

//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@ProductName",productSubscriptionModel.Name),
//                    new SqlParameter("@AmountPerDay",productSubscriptionModel.AmountPerDay),
//                    new SqlParameter("@Code",productSubscriptionModel.Code),
//                    new SqlParameter("@SubscriptionModes",string.Join(",",productSubscriptionModel.SubscriptionModes)),
//                    new SqlParameter("@CreatedBy",productSubscriptionModel.CreatedBy),

//                };
//                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.NotFound, ex);
//            }
//        }
//        public async Task<StatusResponse<List<GetProductModel>>> GetInstitutionProductById(ProductIDModel productIDModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var storedProcedure = SolutionDB.GetProductWithSubscriptionByID;
//                var parameter = new SqlParameter[] { new SqlParameter("ProductID", productIDModel.ProductId) };
//                var result = await curdMiddleware.ExecuteDataReaderList<GetProductModel>(connectionString, storedProcedure, (reader) => new GetProductModel
//                {
//                    ProductID = reader.GetFieldValue<string>("ProductID"),
//                    Name = reader.GetFieldValue<string>("ProductName"),
//                    Code = reader.GetFieldValue<string>("ProductCode"),
//                    AmountPerDay = reader.GetFieldValue<decimal>("AmountPerDay"),
//                    SubscriptionModes = new List<string> { reader.GetFieldValue<string>("SubscriptionModes") },
//                    SubscriptionIds = new List<string> { reader.GetFieldValue<string>("SubscriptionIDs") },
//                    CreatedBy = reader.GetFieldValue<string>("ProductCreatedBy"),
//                    UpdatedBy = reader.GetFieldValue<string>("ProductUpdatedBy"),
//                    CreatedDate = reader.GetFieldValue<DateTime>("ProductCreatedDate"),
//                    UpdatedDate = reader.GetFieldValue<DateTime>("ProductUpdatedDate")
//                }, parameter);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<List<GetProductModel>>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public async Task<StatusResponse<List<GetProductModel>>> GetInstitutionProduct(GetProductModel getProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var storedProcedure = SolutionDB.GetProductWithSubscriptionAndModes;
//                var result = await curdMiddleware.ExecuteDataReaderList<GetProductModel>(connectionString, storedProcedure, (reader) => new GetProductModel
//                {
//                    ProductID = reader.GetFieldValue<string>("ProductID"),
//                    Name = reader.GetFieldValue<string>("ProductName"),
//                    Code = reader.GetFieldValue<string>("ProductCode"),
//                    AmountPerDay = reader.GetFieldValue<decimal>("AmountPerDay"),
//                    SubscriptionModes = (reader.GetFieldValue<string>("SubscriptionModes"))?.Split(',').ToList(),
//                    SubscriptionIds = (reader.GetFieldValue<string>("SubscriptionIDs"))?.Split(',').ToList(),
//                    CreatedBy = reader.GetFieldValue<string>("ProductCreatedBy"),
//                    UpdatedBy = reader.GetFieldValue<string>("ProductUpdatedBy"),
//                    CreatedDate = reader.GetFieldValue<DateTime>("ProductCreatedDate"),
//                    UpdatedDate = reader.GetFieldValue<DateTime>("ProductUpdatedDate")
//                });

//                return result;
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<List<GetProductModel>>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public async Task<StatusResponse<int>> UpdateProduct(UpdateProductModel updateProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@ProductId", updateProductModel.ProductId),
//                    new SqlParameter("@ProductName", updateProductModel.Name),
//                    new SqlParameter("@AmountPerDay", updateProductModel.AmountPerDay),
//                    new SqlParameter("@Code", updateProductModel.Code),
//                    new SqlParameter("@SubscriptionModes", string.Join(",", updateProductModel.SubscriptionModes)),
//                    new SqlParameter("@UpdatedBy", updateProductModel.UpdatedBy)
//                };
//                var storedProcedure = SolutionDB.UpdateProductWithSubscription;
//                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
//                return result;

//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public async Task<StatusResponse<int>> DeleteProduct(ProductIDModel deleteProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@ProductID", deleteProductModel.ProductId)
//                };
//                var storedProcedure = SolutionDB.DeleteInstitutionProduct;
//                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }






//    }
//}
