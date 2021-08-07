using System;

namespace AwesomeGymLive.Application.Queries.GetStudents
{
    public class GetStudentsViewModel
    {
        public GetStudentsViewModel(string fullName, Guid id)
        {
            FullName = fullName;
            Id = id;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
