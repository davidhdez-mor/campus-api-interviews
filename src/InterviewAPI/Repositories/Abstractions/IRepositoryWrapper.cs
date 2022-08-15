using System.Threading.Tasks;

namespace InterviewAPI.Repositories.Abstractions
{
    // Can be Unit of work
    public interface IRepositoryWrapper
    {
        IInterviewRepository Interview { get; }
        Task Save();
    }
}