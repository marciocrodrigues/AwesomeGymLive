using AwesomeGymLive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeGymLive.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetById(Guid id);
        Task<List<Student>> GetContainByName(string name);
    }
}
