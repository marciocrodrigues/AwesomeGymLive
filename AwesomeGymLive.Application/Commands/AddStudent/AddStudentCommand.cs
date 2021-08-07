using MediatR;
using System;

namespace AwesomeGymLive.Application.Commands.AddStudent
{
    public class AddStudentCommand : IRequest<bool>
    {
        public AddStudentCommand(string fullName, DateTime birthDate, Guid idUnit)
        {
            FullName = fullName;
            BirthDate = birthDate;
            IdUnit = idUnit;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Guid IdUnit { get; private set; }
    }
}
