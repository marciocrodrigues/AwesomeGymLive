using AwesomeGymLive.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeGymLive.Application.Queries.GetStudents
{
    public class GetStudentQueryHandler : 
        IRequestHandler<GetStudentQueryById, GetStudentsViewModel>,
        IRequestHandler<GetStudentByName, List<GetStudentsViewModel>>,
        IRequestHandler<GetStudentQueryAll, List<GetStudentsViewModel>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<GetStudentsViewModel> Handle(GetStudentQueryById request, CancellationToken cancellationToken)
        {
            var result = await _studentRepository
                .GetById(request.Id);

            if (result == null)
                return null;

            return new GetStudentsViewModel(result.FullName, result.Id);
        }

        public async Task<List<GetStudentsViewModel>> Handle(GetStudentByName request, CancellationToken cancellationToken)
        {
            var result = await _studentRepository
                .GetContainByName(request.Name);

            if (result.Count == 0)
                return null;

            return result
                .Select(x => new GetStudentsViewModel(x.FullName, x.Id))
                .ToList();
        }

        public async Task<List<GetStudentsViewModel>> Handle(GetStudentQueryAll request, CancellationToken cancellationToken)
        {
            var result = await _studentRepository
                .GetAll();

            if (result.Count == 0)
                return null;

            return result
                .Select(x => new GetStudentsViewModel(x.FullName, x.Id))
                .ToList();
        }
    }
}
