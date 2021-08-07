using MediatR;
using System;
using System.Collections.Generic;

namespace AwesomeGymLive.Application.Queries.GetStudents
{
    public class GetStudentQueryById : IRequest<GetStudentsViewModel>
    {
        public GetStudentQueryById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
