using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult< List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeRequestById { Id = id });
            return Ok(leaveType);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            var command = new CreateLeaveTypeCommand { leaveTypeDto = createLeaveTypeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommand { LeaveType = leaveTypeDto };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
