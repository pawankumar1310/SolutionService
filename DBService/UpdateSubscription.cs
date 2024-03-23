using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class UpdateSubscription : IUpdateSubscription
    {
        private readonly IConfiguration _configuration;
        public UpdateSubscription(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task UpdateSubscriptionAsync(string subscriptionID, string mode, long maximumDays, long minimumDays, string updatedBy)
        {
        try
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("spUpdateSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);
                    command.Parameters.AddWithValue("@Mode", mode);
                    command.Parameters.AddWithValue("@MaximumDays", maximumDays);
                    command.Parameters.AddWithValue("@MinimumDays", minimumDays);
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