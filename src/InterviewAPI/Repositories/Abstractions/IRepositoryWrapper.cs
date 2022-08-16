using System.Threading.Tasks;

namespace InterviewAPI.Repositories.Abstractions
{
    // Can be Unit of work
    public interface IRepositoryWrapper
    {
        IInterviewRepository Interview { get; }
        IIntervieweeRepository Interviewee { get; }
        IInterviewerRepository Interviewer { get; }
        Task Save();
    }
}