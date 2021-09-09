using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Mapper;
using Model.Dto;
using Model.Model;
using Persistence.Repository;

namespace Domain.Service
{
    public class ChapterService
    {

        private readonly ChapterMapper _chapterMapper;

        private readonly ChapterRepository _chapterRepository;

        public ChapterService(ChapterMapper chapterMapper, ChapterRepository chapterRepository)
        {
            _chapterMapper = chapterMapper;
            _chapterRepository = chapterRepository;
        }
        
        public ChapterDto Create(ChapterDto chapterDto)
        {
            var chapter = _chapterMapper.MapToChapter(chapterDto);

            var createdChapter = _chapterRepository.Create(chapter);
            return _chapterMapper.MapToChapterDto(createdChapter.Result);
        }

        public List<ChapterDto> GetAll()
        {
            return _chapterRepository.FindAll()
                .Result
                .ConvertAll(input => _chapterMapper.MapToChapterDto(input));
        }

        public ChapterDto GetChapter(int id)
        {
            var chapter = _chapterRepository.FindById(id);
            return chapter != null ? _chapterMapper.MapToChapterDto(chapter) : null;
        }

        public bool UpdateChapter(int id, ChapterDto chapterDto)
        {
            var chapter = _chapterRepository.FindById(id);
            
            if (chapter == null)
            {
                return true;
            }

            chapter.Description = chapterDto.Description;
            chapter.Name = chapterDto.Name;

            _chapterRepository.Update(chapter);
            return false;
        }

        public bool DeleteChapter(int id)
        {
            var chapter = _chapterRepository.FindById(id);
            
            if (chapter == null)
            {
                return true;
            }
            
            _chapterRepository.Delete(chapter);
            return false;
        }
    }
}