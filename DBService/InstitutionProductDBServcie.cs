//using Model.SolutionService;
//using Shared.DTO.Package;
//using System.Data.SqlClient;
//using System.Globalization;
//using System.Reflection;

//namespace DBService
//{
//    public class InstitutionProductDBService
//    {
//        public string connectionString = Utility.ConfigurationUtility.GetConnectionString();
//        public async Task<StatusResponse<int>> AddInstitutionProduct(AddInstitutionProductModel addInstitutionProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@productSubscriptionID", addInstitutionProductModel.ProductSubscriptionID),
//                    new SqlParameter("@USRinstitutionID", addInstitutionProductModel.USRinstitutionID),
//                    new SqlParameter("@PYMpaymentID", addInstitutionProductModel.PYMpaymentID),
//                    new SqlParameter("@startDate", addInstitutionProductModel.StartDate),
//                    new SqlParameter("@endDate", addInstitutionProductModel.EndDate),
//                    new SqlParameter("@createdBy", addInstitutionProductModel.CreatedBy)
//                };

//                var storedProcedure = SolutionDB.AddInstituteProduct;
//                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
//                return result;

//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }

//        public async Task<StatusResponse<List<InstitutionProductModel>>> GetInstitutionProduct(InstitutionProductModel institutionProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var storedProcedure = SolutionDB.GetInstitutionProduct;
//                var result = await curdMiddleware.ExecuteDataReaderList<InstitutionProductModel>(connectionString, storedProcedure, (reader) => new InstitutionProductModel
//                {
//                    InstitutionProductID = reader["institutionProductID"].ToString()!,
//                    USRInstitutionID = reader["USRinstitutionID"].ToString()!,
//                    ProductSubscriptionID = reader["productSubscriptionID"].ToString()!,
//                    PYMPaymentID = reader["PYMpaymentID"].ToString()!,
//                    StartDate = Convert.ToDateTime(reader["startDate"]),
//                    EndDate = Convert.ToDateTime(reader["endDate"]),
//                    CreatedBy = reader["createdBy"].ToString()!,
//                    UpdatedBy = reader["updatedBy"].ToString()!,
//                    CreatedDate = Convert.ToDateTime(reader["createdDate"], CultureInfo.InvariantCulture),
//                    UpdatedDate = Convert.ToDateTime(reader["updatedDate"], CultureInfo.InvariantCulture)
//                });
//                return result;
//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<List<InstitutionProductModel>>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public async Task<StatusResponse<int>> UpdateInstitutionProduct(UpdateInstitutionProductModel updateInstitutionProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@institutionProductID", updateInstitutionProductModel.InstitutionProductID),
//                    new SqlParameter("@USRinstitutionID", updateInstitutionProductModel.USRInstitutionID),
//                    new SqlParameter("@productSubscriptionID", updateInstitutionProductModel.ProductSubscriptionID),
//                    new SqlParameter("@PYMpaymentID", updateInstitutionProductModel.PYMPaymentID),
//                    new SqlParameter("@startDate", updateInstitutionProductModel.StartDate),
//                    new SqlParameter("@endDate", updateInstitutionProductModel.EndDate),
//                    new SqlParameter("@updatedBy", updateInstitutionProductModel.UpdatedBy)
//                };
//                var storedProcedure = SolutionDB.UpdateInstitutionProduct;
//                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
//                return result;

//            }
//            catch (Exception ex)
//            {
//                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
//            }
//        }
//        public async Task<StatusResponse<int>> DeleteInstitutionProduct(DeleteInstitutionProductModel deleteInstitutionProductModel)
//        {
//            try
//            {
//                CurdMiddleware curdMiddleware = new();
//                var parameter = new SqlParameter[]
//                {
//                    new SqlParameter("@USRinstitutionID", deleteInstitutionProductModel.InstitutionID),
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
