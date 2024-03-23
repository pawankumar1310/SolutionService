using System.Data.SqlClient;
using System.Data;
using Structure;
using Dto;
using System.Globalization;

namespace DBService
{
    public class GetComponent : IGetComponent
    {
        private readonly IConfiguration _configuration;
        public GetComponent(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        
           public async Task<List<GetComponentModel>> GetAllComponentsAsync()
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                    {
                        await connection.OpenAsync();

                        using (SqlCommand command = new SqlCommand("GetAllComponent", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                                List<GetComponentModel> components = new List<GetComponentModel>();

                                while (await reader.ReadAsync())
                                {
                                    GetComponentModel componentModel = new GetComponentModel
                                    {
                                        ComponentID = reader["componentID"].ToString(),
                                        FeatureID = reader["featureID"].ToString(),
                                        Name = reader["name"].ToString(),
                                        Code = reader["code"].ToString(),
                                        CreatedBy = reader["createdBy"].ToString(),
                                        UpdatedBy = reader["updatedBy"].ToString(),
                                        CreatedDate = (DateTime)reader["createdDate"],
                                        UpdatedDate = (DateTime)reader["updatedDate"]
                                    };

                                    components.Add(componentModel);
                                }

                                return components;
                            }
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