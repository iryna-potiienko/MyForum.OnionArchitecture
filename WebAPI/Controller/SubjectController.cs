using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult<SubjectDto>> Create(SubjectDto subjectDto)
        {
            var created = _subjectService.Create(subjectDto);
            if (created == null)
            {
                //ModelState.AddModelError("","Error");
                return BadRequest("Cannot create a subject");
            }
            
            return CreatedAtAction("GetSubject", new { id = created.Id }, created);
        }
        
        [AllowAnonymous]
        [HttpGet("List")]
        public List<SubjectDto> GetCAll()
        {
            return _subjectService.GetAll();
        }
        
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubjectDto>> GetSubject([Required] int id)
        {
            var subjectDto = _subjectService.GetSubject(id);
            if (subjectDto == null)
            {
                return NotFound();
            }

            return subjectDto;
        }

        [Authorize(Roles = "moderator,admin")]
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> PutSubject(int id, [Required] SubjectDto chapterDto)
        {
            var updated = _subjectService.UpdateSubject(id, chapterDto);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [Authorize(Roles = "moderator,admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var deleted = _subjectService.DeleteSubject(id);
            if(deleted)
            {
                return NotFound();
            }
            
            return NoContent();
        } 
    }
}
