using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class AddComponent : IAddComponent
    {
        private readonly IConfiguration _configuration;
        public AddComponent(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task AddComponentAsync(string featureID, string name, string code, string createdBy)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("spAddComponent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@featureID", featureID);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

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