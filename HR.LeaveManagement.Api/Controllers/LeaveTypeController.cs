using HR.LeaveManagement.Application.DTOs.LeaveTypeDtos;
using HR.LeaveManagement.Application.Features.LeaveType.Command.Requests;
using HR.LeaveManagement.Application.Features.LeaveType.Queires.Requests;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediatR= mediator;
            _httpContextAccessor= httpContextAccessor;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leavetypes = await _mediatR.Send(new GetLeaveTypeListRequest());
            return Ok(leavetypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediatR.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<int>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateLeaveTypeRequest { LeaveTypeDto = leaveType };
            var response = await _mediatR.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeRequest { LeaveTypeDto = leaveType };
            await _mediatR.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeRequest { Id = id };
            await _mediatR.Send(command);
            return NoContent();
        }
    }
}
