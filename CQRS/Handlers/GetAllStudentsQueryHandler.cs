using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Udemy.Cqrs.CQRS.Queries;
using Udemy.Cqrs.CQRS.Results;
using Udemy.Cqrs.Data;

namespace Udemy.Cqrs.CQRS.Handlers
{
    public class GetAllStudentsQueryHandler: IRequestHandler<GetAllStudentsQuery, IEnumerable<GetAllStudentsQueryResult>>
    {
        private readonly StudentContext _studentContext;

        public GetAllStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<IEnumerable<GetAllStudentsQueryResult>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentContext.Set<Student>()
                .Select(x => new GetAllStudentsQueryResult() { Id = x.Id, Name = x.Name, Surname = x.Surname })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}