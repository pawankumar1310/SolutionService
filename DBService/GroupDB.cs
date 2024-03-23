using System.Data.SqlClient;
using System.Data;
using Structure;
using Dto;

namespace DBService
{
    public class GroupDB : IGroup
    {
        private readonly IConfiguration _configuration;
        public GroupDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<GroupModel>> GetGroups()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP__GetGroup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            var groups = new List<GroupModel>();

                            while (reader.Read())
                            {
                                var group = new GroupModel
                                {
                                    GroupID = reader["groupID"].ToString(),
                                    Name = reader["name"].ToString(),
                                    Code = reader["code"].ToString()
                                };

                                groups.Add(group);
                            }

                            return groups;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public async Task<int> CreateEntityGroup(EntityGroupModel entityGroup)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP__CreateEntityGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@groupID", entityGroup.GroupID);
                    command.Parameters.AddWithValue("@USRuserID", entityGroup.USRUserID);
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<string> GetGroupNameByGroupId(string groupId)
        {
             using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                using (SqlCommand command = new SqlCommand("SP__GetGroupNameByGroupId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@groupID", groupId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["name"].ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

        }
        public async Task<string> GetGroupName(string usrUserId)
        {
            string groupName = null;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("solutionDBCS")))
            {
                using (SqlCommand command = new SqlCommand("SP__GetGroupNameByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@USRuserID", usrUserId));

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            groupName = reader["GroupName"].ToString();
                        }
                    }
                }
            }

            return groupName;
        }
    }
}