using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class CreateStudentCommandHandler: IRequestHandler<CreateStudentCommand, CreateStudentCommandResult>
    {
        private readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public CreateStudentCommandResult Handle(CreateStudentCommand command)
        {
            var student = _studentContext.Students.Add(
                new Student { Name = command.Name, Surname = command.Surname, Age = command.Age }).Entity;
            var insertId= _studentContext.SaveChanges();
            return new CreateStudentCommandResult()
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname,
                Id = insertId
            };
        }

        public async Task<CreateStudentCommandResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student { Name = request.Name, Surname = request.Surname, Age = request.Age };
            await _studentContext.Students.AddAsync(
                student,cancellationToken);
            await _studentContext.SaveChangesAsync(cancellationToken);
            return new CreateStudentCommandResult()
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname,
                Id = student.Id
            };
        }
    }
}