using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace WebAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChapterController : ControllerBase
    {

        private readonly ChapterService _chapterService;

        public ChapterController( ChapterService chapterService)
        {
            _chapterService = chapterService;
        }


        [Authorize(Roles = "admin")]
        [HttpPost("Create")]
        public async Task<ActionResult<ChapterDto>> Create(ChapterDto chapterDto)
        {
            var created = _chapterService.Create(chapterDto);

            return CreatedAtAction("GetChapter", new {id = created.Id}, created);
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public List<ChapterDto> GetAll()
        {
            return _chapterService.GetAll();
        }
        
        [AllowAnonymous]
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
        
        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
