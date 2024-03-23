using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class DeleteComponent : IDeleteComponent
    {
        private readonly IConfiguration _configuration;
        public DeleteComponent(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task DeleteComponentAsync(string ComponentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("DeleteComponent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@componentID", ComponentID);

                        
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