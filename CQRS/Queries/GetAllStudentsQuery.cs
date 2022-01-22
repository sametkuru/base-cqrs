using System.Collections.Generic;
using MediatR;
using Udemy.Cqrs.CQRS.Results;

namespace Udemy.Cqrs.CQRS.Queries
{
    public class GetAllStudentsQuery: IRequest<IEnumerable<GetAllStudentsQueryResult>>
    {
        
    }
}