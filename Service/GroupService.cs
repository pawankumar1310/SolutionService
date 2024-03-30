using DBService;
using DTO.SolutionService;
using Model.SolutionService;
using Package;


namespace Service
{
    public class GroupService
    {
        public StatusResponse<List<GroupRequest>> GetGroups()
        {
            try
            {
                GroupDBService groupDBService = new();
                var result = groupDBService.GetGroups().Result;
                if (result.Success)
                {
                    List<GroupRequest> groupResponse = new();
                    foreach (var group in result.Data)
                    {
                        groupResponse.Add(new GroupRequest
                        {
                            GroupID = group.GroupID,
                            Name = group.Name,
                            Code = group.Code
                        });
                    }
                    return StatusResponse<List<GroupRequest>>.SuccessStatus(groupResponse, StatusCode.Found);
                }
                else
                {
                    return StatusResponse<List<GroupRequest>>.FailureStatus(StatusCode.NotFound, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<List<GroupRequest>>.FailureStatus(StatusCode.knownException, ex);
            }
        }
        public StatusResponse<int> CreateEntityGroup(CreateEntityGroupRequest createEntityGroup)
        {
            try
            {
                GroupDBService groupDBService = new();
                var addentitygroupmodel = new CreateEntityGroupModel
                {
                   GroupID=createEntityGroup.GroupID,
                   USRUserID=createEntityGroup.USRUserID,
                };
                var result = groupDBService.CreateEntityGroup(addentitygroupmodel).Result;
                if (result.Success)
                {
                    return StatusResponse<int>.SuccessStatus(result.Data, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(result.StatusCode, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
            }
        }
        public StatusResponse<UserGroupRequest> GetUserGroupByUserID(UserIDRequest userID)
        {
            try
            {
                GroupDBService groupDBService = new();
                var userGroupModel = new UserIDModel
                {
                    UserID = userID.USRUserID
                };
                var result= groupDBService.GetUserGroupByUserID(userGroupModel).Result;
                if(result.Success)
                {
                    var groupName = new UserGroupRequest
                    {
                        GroupName = result.Data?.GroupName
                    };
                    return StatusResponse<UserGroupRequest>.SuccessStatus(groupName, StatusCode.Found);
                   
                }
                else
                {
                    return StatusResponse<UserGroupRequest>.FailureStatus(StatusCode.NotFound,new Exception());
                }

            }
            catch(Exception ex)
            {
                return StatusResponse<UserGroupRequest>.FailureStatus(StatusCode.knownException, ex);
            }
        }

    }
}
