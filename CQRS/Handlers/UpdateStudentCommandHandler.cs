using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class UpdateStudentCommandHandler: IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var student = _studentContext.Students.Find(command.Id);
            if (student != null)
            {
                student.Age = command.Age;
                student.Name = command.Name;
                student.Surname = command.Surname;
                _studentContext.SaveChanges();
            }
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Students.FindAsync(request.Id);
            if (student != null)
            {
                student.Age = request.Age;
                student.Name = request.Name;
                student.Surname = request.Surname;
                await _studentContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}