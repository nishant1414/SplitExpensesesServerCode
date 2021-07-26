using Microsoft.AspNetCore.Mvc;
using SplitExpenses.Entities;
using SplitExpenses.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController : Controller
    {
        private GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }
        // get all groups

        [Route("groups")]
        [HttpGet]
        public ActionResult<List<Group>> GetAllGroup()
        {
            return _groupService.GetAllGroup();
        }

        // create group
        [Route("")]
        [HttpPost]
        public ActionResult CreateGroup(Group group)
        {
            _groupService.CreateGroup(group);
            return Ok();
        }

        // get group by groupid
        [Route("group/{id}")]
        [HttpGet]
        public ActionResult<Group> GetGroupById(int id)
        {
            return _groupService.GetGroupById(id);
        }

        // get group by participantid
        [Route("participantId/{participantId}")]
        [HttpGet]
        public ActionResult<List<Group>> GetGroupsByParticipant(int participantId)
        {
            return _groupService.GetGroupsByParticipantId(participantId);
        }

        //get group by emailId
        [Route("participant/email")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Group>> GetGroupsByParticipantEmail(string email)
        {
            try
            {
                var groups =  _groupService.GetGroupsByEmail(email);
                return groups;
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

    }
}
