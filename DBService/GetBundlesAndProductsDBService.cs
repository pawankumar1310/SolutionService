using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using Dto;
using Structure;

namespace DBService
{

    public class GetBundlesAndProductsDBService  : IGetBundleandProduct
    {
        private readonly string _connectionString;

        public GetBundlesAndProductsDBService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("solutionDBCS");
        }



//---------------------------------------------------------- Read a bundle by ID ------------------------------------------------------

        public async Task<GetBundle> GetBundleById(string bundleId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__GetBundleWithProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BundleID", bundleId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        GetBundle bundle = null;

                        while (await reader.ReadAsync())
                        {
                            if (bundle == null)
                            {
                                bundle = new GetBundle
                                {
                                    BundleID = GetValueOrDefault<string>(reader, "BundleID"),
                                    BundleName = GetValueOrDefault<string>(reader, "BundleName"),
                                    BundleCode = GetValueOrDefault<string>(reader, "BundleCode"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "BundleCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "BundleUpdatedBy"),
                                    CreatedDate = (DateTime)reader["BundleCreatedDate"],
                                    UpdatedDate = (DateTime)reader["BundleUpdatedDate"],
                                    products = new List<GetProduct>(),
                                    ProductTotalCost = GetValueOrDefault<decimal>(reader, "ProductTotalCost")
                                };
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("ProductID")))
                            {
                                GetProduct product = new GetProduct
                                {
                                    ProductID = GetValueOrDefault<string>(reader, "ProductID"),
                                    Name = GetValueOrDefault<string>(reader, "ProductName"),
                                    Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                    AmountPerDay = GetValueOrDefault<decimal>(reader, "ProductAmountPerDay"),
                                    subscriptions = new List<GetSubscriptionModel>(),
                                    CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                    CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                    UpdatedDate = (DateTime)reader["ProductUpdatedDate"]
                                };

                                bundle.products.Add(product);
                            }

                            if (GetValueOrDefault<object>(reader, "SubscriptionID") != DBNull.Value)
                            {
                                GetProduct product = bundle.products.Last(); // Get the last added product
                                product.subscriptions.Add(new GetSubscriptionModel
                                {
                                    SubscriptionID = GetValueOrDefault<string>(reader, "SubscriptionID"),
                                    Mode = GetValueOrDefault<string>(reader, "Mode"),
                                    MaximumDays = GetValueOrDefault<double>(reader, "MaximumDays"),
                                    MinimumDays = GetValueOrDefault<double>(reader, "MinimumDays"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "SubscriptionCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "SubscriptionUpdatedBy"),
                                    CreatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionCreatedDate"),
                                    UpdatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionUpdatedDate")
                                });
                            }
                        }

                        return bundle;
                    }
                }
            }
        }



//----------------------------------------------------------- GET ALL BUNDLES ----------------------------------------------------------------------


        public async Task<List<GetBundle>> GetAllBundles()
        {
            List<GetBundle> bundles = new List<GetBundle>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP_GetAllBundlesWithProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            GetBundle bundle = bundles.FirstOrDefault(b => b.BundleID == GetValueOrDefault<string>(reader, "BundleID"));

                            if (bundle == null)
                            {
                                bundle = new GetBundle
                                {
                                    BundleID = GetValueOrDefault<string>(reader, "BundleID"),
                                    BundleName = GetValueOrDefault<string>(reader, "BundleName"),
                                    BundleCode = GetValueOrDefault<string>(reader, "BundleCode"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "BundleCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "BundleUpdatedBy"),
                                    CreatedDate = (DateTime)reader["BundleCreatedDate"],
                                    UpdatedDate = (DateTime)reader["BundleUpdatedDate"],
                                    products = new List<GetProduct>(),
                                    ProductTotalCost = GetValueOrDefault<decimal>(reader, "ProductTotalCost")
                                };

                                bundles.Add(bundle);
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("ProductID")))
                            {
                                GetProduct product = new GetProduct
                                {
                                    ProductID = GetValueOrDefault<string>(reader, "ProductID"),
                                    Name = GetValueOrDefault<string>(reader, "ProductName"),
                                    Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                    AmountPerDay = GetValueOrDefault<decimal>(reader, "ProductAmountPerDay"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                    CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                    UpdatedDate = (DateTime)reader["ProductUpdatedDate"],
                                    subscriptions = new List<GetSubscriptionModel>()
                                };

                                bundle.products.Add(product);
                            }

                            if (GetValueOrDefault<object>(reader, "SubscriptionID") != DBNull.Value)
                            {
                                GetProduct product = bundle.products.Last(); // Get the last added product
                                product.subscriptions.Add(new GetSubscriptionModel
                                {
                                    SubscriptionID = GetValueOrDefault<string>(reader, "SubscriptionID"),
                                    Mode = GetValueOrDefault<string>(reader, "Mode"),
                                    MaximumDays = GetValueOrDefault<double>(reader, "MaximumDays"),
                                    MinimumDays = GetValueOrDefault<double>(reader, "MinimumDays"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "SubscriptionCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "SubscriptionUpdatedBy"),
                                    CreatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionCreatedDate"),
                                    UpdatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionUpdatedDate")
                                });
                            }
                        }
                    }
                }
            }

            return bundles;
        }




//------------------------------------------------------------  GET PRODUCT BY ID --------------------------------------------------------


        public async Task<GetProduct> GetProductById(string productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__GetProductWithSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        GetProduct product = null;

                        while (await reader.ReadAsync())
                        {
                            if (product == null)
                            {
                                product = new GetProduct
                                {
                                    ProductID = GetValueOrDefault<string>(reader, "ProductID"),
                                    Name = GetValueOrDefault<string>(reader, "ProductName"),
                                    Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                    AmountPerDay = GetValueOrDefault<decimal>(reader, "AmountPerDay"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                    CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                    UpdatedDate = (DateTime)reader["ProductUpdatedDate"],
                                    subscriptions = new List<GetSubscriptionModel>()
                                };
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("SubscriptionID")))
                            {
                                product.subscriptions.Add(new GetSubscriptionModel
                                {
                                    SubscriptionID = GetValueOrDefault<string>(reader, "SubscriptionID"),
                                    Mode = GetValueOrDefault<string>(reader, "Mode"),
                                    MaximumDays = GetValueOrDefault<double>(reader, "MaximumDays"),
                                    MinimumDays = GetValueOrDefault<double>(reader, "MinimumDays"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "SubscriptionCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "SubscriptionUpdatedBy"),
                                    CreatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionCreatedDate"),
                                    UpdatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionUpdatedDate")
                                });
                            }
                        }

                        return product;
                    }
                }
            }
        }


//----------------------------------------------------------- GET ALL PRODUCTS ----------------------------------------------------------------

        public async Task<List<GetProduct>> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__GetAllProductsWithSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<GetProduct> products = new List<GetProduct>();
                        GetProduct currentProduct = null;

                        while (await reader.ReadAsync())
                        {
                            string productId = GetValueOrDefault<string>(reader, "ProductID");

                            // Check if it's a new product
                            if (currentProduct == null || currentProduct.ProductID != productId)
                            {
                                // Create a new product
                                currentProduct = new GetProduct
                                {
                                    ProductID = productId,
                                    Name = GetValueOrDefault<string>(reader, "ProductName"),
                                    Code = GetValueOrDefault<string>(reader, "ProductCode"),
                                    AmountPerDay = GetValueOrDefault<decimal>(reader, "AmountPerDay"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "ProductCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "ProductUpdatedBy"),
                                    CreatedDate = (DateTime)reader["ProductCreatedDate"],
                                    UpdatedDate = (DateTime)reader["ProductUpdatedDate"],
                                    subscriptions = new List<GetSubscriptionModel>()
                                };

                                products.Add(currentProduct);
                            }

                            // Check for null or DBNull.Value for SubscriptionID
                            if (GetValueOrDefault<object>(reader, "SubscriptionID") != DBNull.Value)
                            {
                                currentProduct.subscriptions.Add(new GetSubscriptionModel
                                {
                                    SubscriptionID = GetValueOrDefault<string>(reader, "SubscriptionID"),
                                    Mode = GetValueOrDefault<string>(reader, "Mode"),
                                    MaximumDays = GetValueOrDefault<double>(reader, "MaximumDays"),
                                    MinimumDays = GetValueOrDefault<double>(reader, "MinimumDays"),
                                    CreatedBy = GetValueOrDefault<string>(reader, "SubscriptionCreatedBy"),
                                    UpdatedBy = GetValueOrDefault<string>(reader, "SubscriptionUpdatedBy"),
                                    CreatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionCreatedDate"),
                                    UpdatedDate = GetValueOrDefault<DateTime?>(reader, "SubscriptionUpdatedDate")
                                });
                            }
                        }

                        return products;
                    }
                }
            }
        }



//-----------------------------------------------------------------------------------------------------


        private T GetValueOrDefault<T>(SqlDataReader reader, string columnName)
        {
            object value = reader[columnName];

            if (typeof(T) == typeof(double) && value is long)
            {
                // Convert Int64 to Double if the target type is double
                return (T)(object)Convert.ToDouble(value);
            }

            return value == DBNull.Value ? default(T) : (T)value;
        }

    }

}