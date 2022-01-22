using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.CQRS.Handlers;
using Udemy.Cqrs.CQRS.Queries;

namespace Udemy.Cqrs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        // private readonly GetAllStudentsQueryHandler _getAllStudentsQueryHandler;
        // private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        // private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        // private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        //
        // public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetAllStudentsQueryHandler getAllStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        // {
        //     _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //     _getAllStudentsQueryHandler = getAllStudentsQueryHandler;
        //     _createStudentCommandHandler = createStudentCommandHandler;
        //     _removeStudentCommandHandler = removeStudentCommandHandler;
        //     _updateStudentCommandHandler = updateStudentCommandHandler;
        // }

        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(
                new GetAllStudentsQuery()
            );
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}