using MediatR;
using System.Collections.Generic;

namespace AwesomeGymLive.Application.Queries.GetStudents
{
    public class GetStudentByName : IRequest<List<GetStudentsViewModel>>
    {
        public GetStudentByName(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
