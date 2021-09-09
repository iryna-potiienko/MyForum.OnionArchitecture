using Model.Dto;
using MyForum.Models;

namespace Domain.Mapper
{
    public class SubjectMapper
    {
        public Subject MapToSubject(SubjectDto subjectDto)
        {
            var subject = new Subject
            {
                Id = subjectDto.Id,
                Name = subjectDto.Name,
                QuestionText = subjectDto.QuestionText,
                CreatedAt = subjectDto.CreatedAt,
                ChapterId = subjectDto.ChapterId,
                UserId = subjectDto.UserId
            };
            return subject;
        }

        public SubjectDto MapToSubjectDto(Subject subject)
        {
            var subjectDto = new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                QuestionText = subject.QuestionText,
                CreatedAt = subject.CreatedAt,
                ChapterId = subject.ChapterId,
                UserId = subject.UserId
            };
            return subjectDto;
        }
    }
}