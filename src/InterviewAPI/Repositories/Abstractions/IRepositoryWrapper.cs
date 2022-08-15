namespace InterviewAPI.Repositories.Abstractions
{
    // Can be Unit of work
    public interface IRepositoryWrapper
    {
        IInterviewRepository Interview { get; }
        void Save();
    }
}