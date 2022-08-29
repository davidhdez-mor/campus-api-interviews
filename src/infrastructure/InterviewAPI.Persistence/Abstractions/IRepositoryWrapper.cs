using System.Threading.Tasks;
using InterviewAPI.Persistence.Abstractions.Crud;

namespace InterviewAPI.Persistence.Abstractions
{
    public interface IRepositoryWrapper
    {
        IInterviewCrudRepository InterviewRepository { get; }
        IIntervieweeCrudRepository IntervieweeRepository { get; }
        IInterviewerCrudRepository InterviewerRepository { get; }
        
        Task Save();
    }
}