using DBService;
using DTO.SolutionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet("GetGroups")]
        public IActionResult GetGroups()
        {
            try
            {
                GroupService groupService = new();
                return Ok(groupService.GetGroups());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost("CreateEntityGroup")]
        public IActionResult CreateEntityGroup(CreateEntityGroupRequest createEntityGroup)
        {
            if (!string.IsNullOrEmpty(createEntityGroup.USRUserID) || !string.IsNullOrEmpty(createEntityGroup.GroupID))
            {
                try
                {
                    GroupService groupService = new();
                    return Ok(groupService.CreateEntityGroup(createEntityGroup));
                }
                catch
                {
                    return StatusCode(500);
                }

            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost("GetUserGroupByUserID")]
        public IActionResult GetUserGroupByUserID(UserIDRequest userIDRequest)
        {
            if (!string.IsNullOrEmpty(userIDRequest.USRUserID))
            {
                try
                {
                    GroupService groupService = new();
                    return Ok(groupService.GetUserGroupByUserID(userIDRequest));
                }
                catch
                {
                    return StatusCode(500);
                }

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
