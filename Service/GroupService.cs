using DBService;
using Dto;
using Structure;

namespace Service
{
    public class GroupService
    {
        private readonly IGroup _group;
        // private readonly FeatureDBService _featureDBService;

        public GroupService(IGroup group)
        {
           _group = group;
        }
        public async Task<List<GroupModel>> GetGroupService()
        {
            List<GroupModel> result = await _group.GetGroups();
            return result;
        }
        public async Task<int> UserGroupService(EntityGroupModel entityGroupModel)
        {
            int result = await _group.CreateEntityGroup(entityGroupModel);
            return result;
        }

        public async Task<string> GetGroupNameByGroupId(string groupId)
        {
            return await _group.GetGroupNameByGroupId(groupId);
        }
        public async Task<string> GetGroupName(string usrUserId)
        {
            return await _group.GetGroupName(usrUserId);
        }

    }
}
