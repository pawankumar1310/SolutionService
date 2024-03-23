using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Dto;
using Structure;

namespace DBService
{
    public class ProductDBService : IProductService
    {

        private readonly string _connectionString;

        public ProductDBService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("solutionDBCS");
        }


//-------------------------------------- ADD PRODUCT ---------------------------------

        public async Task<bool> InsertProductWithSubscription(CreateProductRequest productRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__InsertProductWithSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductName", productRequest.Name);
                    command.Parameters.AddWithValue("@AmountPerDay", productRequest.AmountPerDay);
                    command.Parameters.AddWithValue("@Code", productRequest.Code);
                    command.Parameters.AddWithValue("@SubscriptionModes", string.Join(",", productRequest.SubscriptionModes));
                    command.Parameters.AddWithValue("@CreatedBy", productRequest.CreatedBy);

                    await command.ExecuteNonQueryAsync();

                    return true;
                }
            }
        }



        //--------------------------------------- GET PRODUCT BY ID ------------------------------------

            public async Task<Product> GetProductById(string productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__GetProductWithSubscriptionsAndModes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Product
                            {
                                ProductID = GetValueOrDefault<string>(reader, "ProductID"),
                                Name = GetValueOrDefault<string>(reader, "ProductName"),
                                Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                AmountPerDay = GetValueOrDefault<decimal>(reader, "AmountPerDay"),
                                SubscriptionModes = GetSubscriptionModes(reader),
                                SubscriptionIds = GetSubscriptionIds(reader),
                                CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                UpdatedDate = (DateTime)reader["ProductUpdatedDate"],
                            };
                        }
                        else
                        {
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

        private List<string> GetSubscriptionModes(SqlDataReader reader)
        {
            string subscriptionModes = GetValueOrDefault<string>(reader, "SubscriptionModes");
            return string.IsNullOrEmpty(subscriptionModes) ? new List<string>() : subscriptionModes.Split(',').ToList();
        }


        private List<string> GetSubscriptionIds(SqlDataReader reader)
        {
            string subscriptionIds = GetValueOrDefault<string>(reader, "SubscriptionIDs");
            return string.IsNullOrEmpty(subscriptionIds) ? new List<string>() : subscriptionIds.Split(',').ToList();
        }


//--------------------------------------- GET ALL PRODUCTS -------------------------------------------


        public async Task<List<Product>> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__GetAllProductsWithSubscriptionsAndModes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<Product> products = new List<Product>();

                        while (await reader.ReadAsync())
                        {
                            Product product = new Product
                            {
                                ProductID = GetValueOrDefault<string>(reader, "ProductID"),
                                Name = GetValueOrDefault<string>(reader, "ProductName"),
                                Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                AmountPerDay = GetValueOrDefault<decimal>(reader, "AmountPerDay"),
                                SubscriptionModes = GetSubscriptionModes(reader),
                                CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                UpdatedDate = (DateTime)reader["ProductUpdatedDate"],
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                }
            }
        }






//-------------------------------------------- UPDATE PRODUCTS ------------------------------------------

        public async Task UpdateProductWithSubscription(string productId, UpdateProductRequest productUpdateRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__UpdateProductWithSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@ProductName", productUpdateRequest.Name);
                    command.Parameters.AddWithValue("@AmountPerDay", productUpdateRequest.AmountPerDay);
                    command.Parameters.AddWithValue("@Code", productUpdateRequest.Code);
                    command.Parameters.AddWithValue("@SubscriptionModes", string.Join(",", productUpdateRequest.SubscriptionModes));
                   
                    command.Parameters.AddWithValue("@UpdatedBy", productUpdateRequest.UpdatedBy);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }







//------------------------------------------- DELETE PRODUCT ------------------------------------------------

        public async Task DeleteProduct(string productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__DeleteProductWithSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}