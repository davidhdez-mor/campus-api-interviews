namespace InterviewAPI.Entities.Models
{
    public class InterviewInterviewer
    {
        // public int Id { get; set; }
        public int InterviewId { get; set; }
        public int InterviewerId { get; set; }
        public Interview Interview { get; set; }
        public Interviewer Interviewer { get; set; }
    }
}