using System.Data.SqlClient;
using System.Data;
using Structure;

namespace DBService
{
    public class FeatureDBService : IFeatures
    {
        private readonly string _connectionString;

        public FeatureDBService(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("SaSolutionDB");

        }

        public async Task<List<string>> GetFeatureCodeByUserId(string userId)
        {
            List<string> featureCodes = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetFeatureCodeByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            featureCodes.Add(reader["code"].ToString());
                        }
                    }
                }
            }

            return featureCodes;
        }
    }
}

