using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newproject.Context;
using Newproject.Features.Command;
using Newproject.Features.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator) => _mediator = mediator;
       
        [HttpGet]
        public async Task<IEnumerable<TblDoctor>> GetTblDoctors() => await _mediator.Send(new GetDoctor.Query());
       
        [HttpGet("{id}")]
        public async Task<TblDoctor> GetDoctor(int id) => await _mediator.Send(new GetDoctorById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult> CreateDoctor([FromBody] AddDoctor.Command command)
        {
            var createdDoctorId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDoctor), new { id = createdDoctorId }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _mediator.Send(new DeleteDoctor.Command { Id = id });
            return NoContent();
        }
    }
}
