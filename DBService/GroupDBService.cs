using Middleware;
using Model.SolutionService;
using Package;
using System.Data;
using System.Data.SqlClient;
using Constants.StoredProcedure;
namespace DBService
{
    public class GroupDBService
    {
        string connectionString=Utility.ConfigurationUtility.GetConnectionString();
        public async Task<StatusResponse<List<GroupModel>>> GetGroups()
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var storedProcedure = SolutionDB.GetGroups;
                var result = await curdMiddleware.ExecuteDataReaderList<GroupModel>(
                    connectionString, storedProcedure,
                    (reader) => new GroupModel
                    {
                        GroupID = reader["groupID"].ToString()!,
                        Name = reader["name"].ToString()!,
                        Code = reader["code"].ToString()!

                    });
                if (result != null)
                {
                    return StatusResponse<List<GroupModel>>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<List<GroupModel>>.FailureStatus(StatusCode.NotFound, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<List<GroupModel>>.FailureStatus(StatusCode.knownException, ex);
            }

        }
        public async Task<StatusResponse<int>> CreateEntityGroup(CreateEntityGroupModel createEntityGroup)
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var parameter = new SqlParameter[]
                {
                    new SqlParameter("@groupID", createEntityGroup.GroupID),
                    new SqlParameter("@USRuserID", createEntityGroup.USRUserID),
                    
                };

                var storedProcedure = SolutionDB.CreateEntityGroup;
                var result = await curdMiddleware.ExecuteNonQuery(connectionString, storedProcedure, parameter);
                if(result>0)
                {
                    return StatusResponse<int>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(StatusCode.NotFound, new Exception());
                }

            }
            catch (Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
            }
        }
        public async Task<StatusResponse<UserGroupResponse>> GetUserGroupByUserID(UserIDModel userIDModel)
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var storedProcedure = SolutionDB.GetUserGroup;
                var parameter = new SqlParameter[] { new SqlParameter("@USRuserID", userIDModel.UserID) };
                var result = await curdMiddleware.ExecuteDataReaderSingle<UserGroupResponse>(connectionString, storedProcedure, (reader) => new UserGroupResponse
                {
                    GroupName = reader["GroupName"].ToString()!,
                }, parameter);
                if (result != null)
                {
                    return StatusResponse<UserGroupResponse>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<UserGroupResponse>.FailureStatus(StatusCode.NotFound, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<UserGroupResponse>.FailureStatus(StatusCode.knownException, ex);
            }
        }
    }
}
