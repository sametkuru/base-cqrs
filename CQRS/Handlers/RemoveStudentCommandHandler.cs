using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Udemy.Cqrs.CQRS.Commands;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class RemoveStudentCommandHandler: IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Students.FindAsync(request.Id);
            
            if (student != null)
            {
                _studentContext.Remove(student);
                await _studentContext.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}