using MediatR;
using Udemy.Cqrs.CQRS.Results;

namespace Udemy.Cqrs.CQRS.Queries
{
    public class GetStudentByIdQuery:IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}