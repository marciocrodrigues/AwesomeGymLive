using AwesomeGymLive.Application.Commands.AddStudent;
using AwesomeGymLive.Application.Queries.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGymLive.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody]AddStudentInputModel input)
        {
            var addStudentCommand = new AddStudentCommand(input.FullName, input.BirthDate, Guid.NewGuid());

            var result = await _mediator.Send(addStudentCommand);

            if (result)
                return Ok("Estudante inserido com sucesso"); 

            return BadRequest("Erro ao tentar inserir novo estudante");
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            var getStudentQueryAll = new GetStudentQueryAll();

            var result = await _mediator.Send(getStudentQueryAll);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var getStudentsQueryById = new GetStudentQueryById(id);

            var result = await _mediator.Send(getStudentsQueryById);

            return Ok(result);
        }

        [HttpPost]
        [Route("searchbyname/{name}")]
        public async Task<IActionResult> GetForName(string name)
        {
            var getStudentQueryByName = new GetStudentByName(name);

            var result = await _mediator.Send(getStudentQueryByName);

            return Ok(result);
        }
    }
}
