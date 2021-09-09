using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Mapper;
using Model.Dto;
using Persistence.Repository;

namespace Domain.Service
{
    public class SubjectService
    {
        
        private readonly SubjectMapper _subjectMapper;

        private readonly SubjectRepository _subjectRepository;

        public SubjectService(SubjectMapper subjectMapper, SubjectRepository subjectRepository)
        {
            _subjectMapper = subjectMapper;
            _subjectRepository = subjectRepository;
        }
        
        public SubjectDto Create(SubjectDto subjectDto)
        {
            var subject = _subjectMapper.MapToSubject(subjectDto);

            var createdChapter = _subjectRepository.Create(subject);
            return _subjectMapper.MapToSubjectDto(createdChapter.Result);
        }

        public List<SubjectDto> GetAll()
        {
            return _subjectRepository.FindAll()
                .Result
                .ConvertAll(input => _subjectMapper.MapToSubjectDto(input));
        }

        public SubjectDto GetSubject(int id)
        {
            var chapter = _subjectRepository.FindById(id);
            return chapter != null ? _subjectMapper.MapToSubjectDto(chapter) : null;
        }

        public bool UpdateSubject(int id, SubjectDto subjectDto)
        {
            var subject = _subjectRepository.FindById(id);
            
            if (subject == null)
            {
                return true;
            }

            subject.Name = subjectDto.Name;
            subject.QuestionText = subjectDto.QuestionText;
            subject.CreatedAt = subjectDto.CreatedAt;
            subject.ChapterId = subjectDto.ChapterId;
            subject.UserId = subjectDto.UserId;

            _subjectRepository.Update(subject);
            return false;
        }

        public bool DeleteSubject(int id)
        {
            var subject = _subjectRepository.FindById(id);
            
            if (subject == null)
            {
                return true;
            }
            
            _subjectRepository.Delete(subject);
            return false;
        }
    }
}