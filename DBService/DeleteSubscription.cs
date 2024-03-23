using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class DeleteSubscription : IDeleteSubscription
    {
        private readonly IConfiguration _configuration;
        public DeleteSubscription(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task DeleteSubscriptionAsync(string SubscriptionId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("DeleteSubscription", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionId);

                        
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}