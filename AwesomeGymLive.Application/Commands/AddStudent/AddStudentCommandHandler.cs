using AwesomeGymLive.Domain.Entities;
using AwesomeGymLive.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeGymLive.Application.Commands.AddStudent
{
    public class AddStudentCommandHandler :
        IRequestHandler<AddStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.FullName, request.BirthDate);
            _studentRepository.Add(student);

            return await _studentRepository.UnitOfWork.Commit();
        }
    }
}
