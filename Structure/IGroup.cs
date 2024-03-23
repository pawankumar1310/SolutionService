using Dto;

namespace Structure
{
    public interface IGroup
    {
        public Task<List<GroupModel>> GetGroups();
        public Task<int> CreateEntityGroup(EntityGroupModel entityGroup);

        public Task<string> GetGroupNameByGroupId(string groupId);
        public Task<string> GetGroupName(string usrUserId);
        
    }
}
