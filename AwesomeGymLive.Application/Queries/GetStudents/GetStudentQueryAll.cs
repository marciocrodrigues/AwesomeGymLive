using MediatR;
using System.Collections.Generic;

namespace AwesomeGymLive.Application.Queries.GetStudents
{
    public class GetStudentQueryAll : IRequest<List<GetStudentsViewModel>>
    {
    }
}
