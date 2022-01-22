using MediatR;
using Udemy.Cqrs.CQRS.Results;

namespace Udemy.Cqrs.CQRS.Commands
{
    public class CreateStudentCommand: IRequest<CreateStudentCommandResult>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}