using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using Dto;
using Structure;

namespace DBService
{

    public class BundleDBService : IBundleService
    {
        private readonly string _connectionString;

        public BundleDBService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("solutionDBCS");
        }

//-------------------------------- Create a new bundle -----------------------------------

        public async Task<bool> InsertBundleWithProducts(BundleCreationRequest bundleCreationRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("InsertBundleWithProductsSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@BundleName", bundleCreationRequest.BundleName);
                    command.Parameters.AddWithValue("@BundleCode", bundleCreationRequest.BundleCode);
                    command.Parameters.AddWithValue("@ProductsName", string.Join(",", bundleCreationRequest.Products));
                    command.Parameters.AddWithValue("@CreatedBy", bundleCreationRequest.CreatedBy);


                    // Execute the stored procedure
                    await command.ExecuteNonQueryAsync();
                    

                    return true;
                }   
            }
        }
 //---------------------------------- Read a bundle by ID --------------------------------------

        public async Task<Bundle> GetBundleById(string bundleId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("GetBundleWithProductsAndTotalCostSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BundleID", bundleId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // Map reader data to a Bundle object
                            Bundle bundle = new Bundle
                            {
                                BundleID = GetValueOrDefault<string>(reader, "BundleID"),
                                BundleName = GetValueOrDefault<string>(reader, "BundleName"),
                                BundleCode = GetValueOrDefault<string>(reader, "BundleCode"),
                                CreatedBy = GetValueOrDefault<string>(reader, "BundleCreatedBy"),
                                UpdatedBy = GetValueOrDefault<string>(reader, "BundleUpdatedBy"),
                                CreatedDate = (DateTime)reader["BundleCreatedDate"],
                                UpdatedDate = (DateTime)reader["BundleUpdatedDate"],
                                ProductName = GetProductNames(reader),
                                ProductTotalCost = GetValueOrDefault<decimal>(reader, "TotalCost"),
                            };

                            return bundle;
                        }
                        else
                        {
                            // Handle the case where the bundle was not found
                            return null;
                        }
                    }
                }
            }
        }

        private T GetValueOrDefault<T>(SqlDataReader reader, string columnName)
        {
            object value = reader[columnName];
            return value == DBNull.Value ? default(T) : (T)value;
        }

        private List<string> GetProductNames(SqlDataReader reader)
        {
            string productNames = GetValueOrDefault<string>(reader, "ProductNames");
            return string.IsNullOrEmpty(productNames) ? new List<string>() : productNames.Split(',').ToList();
        }


        //-------------------------------------- GET ALL BUNDLES --------------------------------------


        public async Task<List<Bundle>> GetAllBundles()
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        await connection.OpenAsync();

        using (SqlCommand command = new SqlCommand("GetAllBundlesWithProductsAndTotalCostSP", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Bundle> bundles = new List<Bundle>();

                while (reader.Read())
                {
                    Bundle bundle = new Bundle
                    {
                        BundleID = reader["BundleID"].ToString(),
                        BundleName = reader["BundleName"].ToString(),
                        BundleCode = reader["BundleCode"].ToString(),
                        CreatedBy = reader["BundleCreatedBy"].ToString(),
                        UpdatedBy = reader["BundleUpdatedBy"].ToString(),
                        CreatedDate = (DateTime)reader["BundleCreatedDate"],
                        UpdatedDate = (DateTime)reader["BundleUpdatedDate"],
                        ProductName = ((string)reader["ProductNames"]).Split(',').ToList(),
                        ProductTotalCost = reader["TotalCost"] != DBNull.Value ? (decimal)reader["TotalCost"] : 0m,
                    };

                    bundles.Add(bundle);
                }

                return bundles;
            }
        }
    }
}


//-------------------------------------- Update a bundle --------------------------------------

        public async Task UpdateBundleWithProducts(string bundleID, BundleUpdateRequest bundleUpdateRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateBundleWithProductsSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@BundleID", bundleID);
                    command.Parameters.AddWithValue("@NewBundleName", bundleUpdateRequest.BundleName);
                    command.Parameters.AddWithValue("@NewBundleCode", bundleUpdateRequest.BundleCode);
                    command.Parameters.AddWithValue("@NewProductsName", string.Join(",", bundleUpdateRequest.Products));
                    //command.Parameters.Add("@NewProductsName", SqlDbType.Xml).Value = GenerateXmlParameter(bundleUpdateRequest.Products);
                    command.Parameters.AddWithValue("@UpdatedBy", bundleUpdateRequest.UpdatedBy);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


       


// --------------------------------------  Delete a bundle by ID -------------------------------

        public async Task DeleteBundle(string bundleId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DeleteBundleSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BundleID", bundleId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}