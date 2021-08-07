using System;

namespace AwesomeGymLive.Domain.Entities
{
    public class Student
    {
        protected Student()
        {

        }
        public Student(string fullName, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            BirthDate = birthDate;
            Active = true;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
    }
}
