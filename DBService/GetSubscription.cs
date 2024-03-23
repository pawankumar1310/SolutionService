using System.Data.SqlClient;
using System.Data;
using Structure;
using Dto;
using System.Globalization;

namespace DBService
{
    public class GetSubscription : IGetSubscription
    {
        private readonly IConfiguration _configuration;
        public GetSubscription(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        
       public async Task<List<GetSubscriptionModel>> GetAllSubscriptionsAsync()
    {
        try
        {
            List<GetSubscriptionModel> subscriptions = new List<GetSubscriptionModel>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("GetAllSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        

                         while (await reader.ReadAsync())
                            {                    
                                    GetSubscriptionModel getSubscriptionModel = new GetSubscriptionModel
                                    {
                                       SubscriptionID = reader["subscriptionID"].ToString(),
                                        Mode = reader["mode"].ToString(),
                                        MaximumDays = Convert.ToDouble(reader["maximumDays"]),
                                        MinimumDays = Convert.ToDouble(reader["minimumdays"]),
                                        CreatedBy = reader["createdBy"].ToString(),
                                        UpdatedBy = reader["updatedBy"].ToString(),
                                        CreatedDate = Convert.ToDateTime(reader["createdDate"], CultureInfo.InvariantCulture),
                                        UpdatedDate = Convert.ToDateTime(reader["updatedDate"], CultureInfo.InvariantCulture)
                                    };
                                    subscriptions.Add(getSubscriptionModel);  
                            }

                        
                    }
                }
            }
            return subscriptions;
        }
        catch (Exception ex)
        {
            // Handle exception (log, throw, etc.)
            throw;
        }
    }

        public async Task<GetSubscriptionModel> GetAllSubscriptionByIdAsync(string subscriptionID)
        {
            try
            {
                //List<GetSubscriptionModel> subscriptions = new List<GetSubscriptionModel>();
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("GetSubscriptionById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@subscriptionID", subscriptionID);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            

                            if (await reader.ReadAsync())
                                {                    
                                    GetSubscriptionModel getSubscriptionModel = new GetSubscriptionModel
                                    {
                                        SubscriptionID = reader["subscriptionID"].ToString(),
                                            Mode = reader["mode"].ToString(),
                                            MaximumDays = Convert.ToDouble(reader["maximumDays"]),
                                            MinimumDays = Convert.ToDouble(reader["minimumdays"]),
                                            CreatedBy = reader["createdBy"].ToString(),
                                            UpdatedBy = reader["updatedBy"].ToString(),
                                            CreatedDate = Convert.ToDateTime(reader["createdDate"], CultureInfo.InvariantCulture),
                                            UpdatedDate = Convert.ToDateTime(reader["updatedDate"], CultureInfo.InvariantCulture)
                                    };
                                    return getSubscriptionModel;  
                                }

                            
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw;
            }
        }
    }
}
