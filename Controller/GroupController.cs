using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Structure;
using System.Data.SqlClient;
using System.Data;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet("Group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
              List<GroupModel> group = await _groupService.GetGroupService();

                if (group != null)
                {
                    return Ok(group);
                }
                else
                {
                    return NotFound("Group not found");
                }
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntityGroup([FromBody] EntityGroupModel entityGroup)
        {
            try
            {
                int result=await _groupService.UserGroupService(entityGroup);
                if (result > 0)
                {
                    return Ok("Entity group created successfully");
                }
                else
                {
                    return BadRequest("Invalid Group");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetGroupName/{groupId}")]
        public async Task<IActionResult> GetGroupNameByGroupId(string groupId)
        {
            try
            {
                var groupName = await _groupService.GetGroupNameByGroupId(groupId);
                if(groupName != null)
                {
                    return Ok(groupName);
                }
                else
                {
                    return BadRequest("Unbale to get group Id");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetGroupNameByUserId")]
        public async Task<IActionResult> GetGroupNameByUserId(string usrUserId)
        {
            try
            {
                string groupName = await _groupService.GetGroupName(usrUserId);

                if (groupName != null)
                {
                    return Ok(new { GroupName = groupName });
                }
                else
                {
                    return NotFound(new { Message = "Group not found for the given USRuserID." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

        
    }
}

