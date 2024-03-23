using System.Data.SqlClient;
using System.Data;
using Structure;
using DTO;
using System.Reflection;
using Dto;
using System.Globalization;

namespace DBService
{
    public class AddInstituteProductDb : IAddInstitutionProduct
    {
        private readonly IConfiguration _configuration;
        public AddInstituteProductDb(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task<int> AddInstituteProduct(InstitutionProductModel model)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("spInsertInstitutionProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@USRinstitutionID", model.USRinstitutionID);
                    command.Parameters.AddWithValue("@productSubscriptionID", model.ProductSubscriptionID);
                    command.Parameters.AddWithValue("@PYMpaymentID", model.PYMpaymentID);
                    command.Parameters.AddWithValue("@startDate", model.StartDate);
                    command.Parameters.AddWithValue("@endDate", model.EndDate);
                    command.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                    //-------------adding ---------------------//


                    return await command.ExecuteNonQueryAsync();
                }

            }

        }
        public async Task<int> DeleteInstitutionProductAsync(string USRinstitutionID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP__DeleteInstitutionProductByUSRinstitutionID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@USRinstitutionID", USRinstitutionID);


                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> UpdateInstituteProduct(string institutionProductID,UpdateInstitutionProductModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP__UpdateInstitutionProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@institutionProductID", institutionProductID);
                        command.Parameters.AddWithValue("@USRinstitutionID", model.USRInstitutionID);
                        command.Parameters.AddWithValue("@productSubscriptionID", model.ProductSubscriptionID);
                        command.Parameters.AddWithValue("@PYMpaymentID", model.PYMPaymentID);
                        command.Parameters.AddWithValue("@startDate", model.StartDate);
                        command.Parameters.AddWithValue("@endDate", model.EndDate);
                        command.Parameters.AddWithValue("@updatedBy", model.UpdatedBy);
                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public async Task<List<InstitutionProductModelForGetAll>> GetAllInstituteProductsAsync()
        {
            try
            {
                List<InstitutionProductModelForGetAll> ip = new List<InstitutionProductModelForGetAll>();
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP__GetAllInstitutionProducts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {


                            while (await reader.ReadAsync())
                            {
                                InstitutionProductModelForGetAll getip = new InstitutionProductModelForGetAll
                                {
                                    InstitutionProductID = reader["institutionProductID"].ToString(),
                                    USRInstitutionID = reader["USRinstitutionID"].ToString(),
                                    ProductSubscriptionID = reader["productSubscriptionID"].ToString(),
                                    PYMPaymentID = reader["PYMpaymentID"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["startDate"]),
                                    EndDate = Convert.ToDateTime(reader["endDate"]),
                                    CreatedBy = reader["createdBy"].ToString(),
                                    UpdatedBy = reader["updatedBy"].ToString(),
                                    CreatedDate = Convert.ToDateTime(reader["createdDate"], CultureInfo.InvariantCulture),
                                    UpdatedDate = Convert.ToDateTime(reader["updatedDate"], CultureInfo.InvariantCulture)
                                    
                                };
                                ip.Add(getip);
                            }


                        }
                    }
                }
                return ip;
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw;
            }
        }

    }
}