using AwesomeGymLive.Application.Queries;
using AwesomeGymLive.Domain;
using AwesomeGymLive.Domain.Entities;
using AwesomeGymLive.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGymLive.Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(StudentQueries.GetById(id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetContainByName(string name)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(StudentQueries.GetContainByName(name))
                .OrderBy(x => x.FullName)
                .ToListAsync();
        }
    }
}
