using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class AddSubscription : IAddSubscription
    {
        private readonly IConfiguration _configuration;
        public AddSubscription(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task AddSubscriptionAsync(string? mode, string? createdBy, long? maximumDays, long? minimumDays)
        {
        try
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("spAddSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@mode", mode);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@maximumDays", maximumDays);
                    command.Parameters.AddWithValue("@minimumDays", minimumDays);

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