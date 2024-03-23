using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class UpdateComponent : IUpdateComponent
    {
        private readonly IConfiguration _configuration;
        public UpdateComponent(IConfiguration configuration)
        {
            _configuration=configuration;
        }
         public async Task UpdateComponentAsync(string componentID, string featureID, string name, string code, string updatedBy)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                    {
                        await connection.OpenAsync();

                        using (SqlCommand command = new SqlCommand("spUpdateComponent", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Parameters
                            command.Parameters.AddWithValue("@ComponentID", componentID);
                            command.Parameters.AddWithValue("@FeatureID", featureID);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Code", code);  
                            command.Parameters.AddWithValue("@UpdatedBy", updatedBy);

                            // Execute the stored procedure
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log, throw, etc.)
                    throw;
                }
            }
    }
}