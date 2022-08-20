using InterviewAPI.Persistence.Abstractions.ReadOnly;

namespace InterviewAPI.Persistence.Abstractions
{
    public interface IReadOnlyWrapper
    {
        IInterviewReadOnlyRepository InterviewReadOnlyRepository { get; }
        IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository { get; }
        IInterviewerReadOnlyRepository InterviewerReadOnlyRepository { get; }
    }
}