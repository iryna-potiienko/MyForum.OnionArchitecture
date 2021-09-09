using Model.Dto;
using Model.Model;

namespace Domain.Mapper
{
    public class ChapterMapper
    {

        public Chapter MapToChapter(ChapterDto dto)
        {
            var chapter = new Chapter
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };


            return chapter;
        }

        public ChapterDto MapToChapterDto(Chapter chapter)
        {
            var chapterDto = new ChapterDto
            {
                Id = chapter.Id,
                Name = chapter.Name, 
                Description = chapter.Description
            };

            return chapterDto;
        }
        
    }
}