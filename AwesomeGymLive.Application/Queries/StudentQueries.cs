using AwesomeGymLive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AwesomeGymLive.Application.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Student, bool>> GetContainByName(string name)
        {
            return x => x.FullName.ToLower().Contains(name);
        }
    }
}
