using InterviewAPI.Persistence.Abstractions.Queries;

namespace InterviewAPI.Persistence.Abstractions
{
    public interface  IRepositoryReadOnlyWrapper
    {
        IInterviewReadOnlyRepository InterviewReadOnlyRepository { get; }
        IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository { get; }
        IInterviewerReadOnlyRepository InterviewerReadOnlyRepository { get; }
        
    }
}