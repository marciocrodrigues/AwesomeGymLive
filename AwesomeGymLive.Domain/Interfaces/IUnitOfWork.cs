using System.Threading.Tasks;

namespace AwesomeGymLive.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
