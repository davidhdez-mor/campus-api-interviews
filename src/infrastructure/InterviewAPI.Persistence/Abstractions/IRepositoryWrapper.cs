using System.Threading.Tasks;
using InterviewAPI.Persistence.Abstractions.Commands;
using InterviewAPI.Persistence.Abstractions.Queries;

namespace InterviewAPI.Persistence.Abstractions
{
    // Can be Unit of work
    public interface IRepositoryWrapper
    {
        IInterviewCrudRepository InterviewRepository { get; }
        IIntervieweeCrudRepository IntervieweeRepository { get; }
        IInterviewerCrudRepository InterviewerRepository { get; }
        
        IInterviewReadOnlyRepository InterviewReadOnlyRepository { get; }
        IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository { get; }
        IInterviewerReadOnlyRepository InterviewerReadOnlyRepository { get; }
        Task Save();
    }
}