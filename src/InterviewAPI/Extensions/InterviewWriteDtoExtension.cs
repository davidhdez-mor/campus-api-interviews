using InterviewAPI.DTOs;
using InterviewAPI.Models;

namespace InterviewAPI.Extensions
{
    public static class InterviewWriteDtoExtension
    {
        public static Interview ToInterview(this InterviewWriteDto interviewWriteDto)
        {
            int intervieweeId = interviewWriteDto.IntervieweeId;
            var interviewerIds = interviewWriteDto.InterviewerIds;



            Interview interview = new Interview()
            {
                Appointment = interviewWriteDto.Appointment,

            };
            return interview;
        }
    }
}