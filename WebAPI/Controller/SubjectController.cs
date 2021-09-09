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
            
            return CreatedAtAction("GetSubject", new { id = created.Id }, created);
        }
        
        [HttpGet("List")]
        public List<SubjectDto> GetCAll()
        {
            return _subjectService.GetAll();
        }
        
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
