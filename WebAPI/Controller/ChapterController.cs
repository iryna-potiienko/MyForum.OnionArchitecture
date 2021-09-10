using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace WebAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {

        private readonly ChapterService _chapterService;

        public ChapterController( ChapterService chapterService)
        {
            _chapterService = chapterService;
        }
        

        [HttpPost("Create")]
        public async Task<ActionResult<ChapterDto>> Create(ChapterDto chapterDto)
        {
            var created = _chapterService.Create(chapterDto);
            
            return CreatedAtAction("GetChapter", new { id = created.Id }, created);
        }
        
        [HttpGet("List")]
        public List<ChapterDto> GetAll()
        {
            return _chapterService.GetAll();
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ChapterDto>> GetChapter([Required] int id)
        {
            var chapterDto = _chapterService.GetChapter(id);
            if (chapterDto == null)
            {
                return NotFound();
            }

            return chapterDto;
        }
        
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> PutChapter(int id, [Required] ChapterDto chapterDto)
        {
            var updated = _chapterService.UpdateChapter(id, chapterDto);
            if(updated)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var deleted = _chapterService.DeleteChapter(id);
            if (deleted)
            {
                return NotFound();
            }

            return NoContent();
        } 
    }
}
