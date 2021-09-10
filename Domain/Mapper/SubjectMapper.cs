using Model.Dto;
using Model.Model;

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
                UserName = subjectDto.UserName
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
                UserName = subject.UserName
            };
            return subjectDto;
        }
    }
}