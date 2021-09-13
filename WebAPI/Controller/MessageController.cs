using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Persistence;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController( MessageService messageService)
        {
            _messageService = messageService;
        }
        

        [HttpPost("Create")]
        public async Task<ActionResult<MessageDto>> Create(MessageDto messageDto)
        {
            var created = _messageService.Create(messageDto);
            if (created == null)
            {
                ModelState.AddModelError("","Error");
                //return BadRequest("Cannot create a message");
                return BadRequest();
            }

            return CreatedAtAction("GetMessage", new { id = created.Id }, created);
        }
        
        [AllowAnonymous]
        [HttpGet("List")]
        public List<MessageDto> GetAll()
        {
            return _messageService.GetAll();
        }
        
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MessageDto>> GetMessage([Required] int id)
        {
            var messageDto = _messageService.GetMessage(id);
            if (messageDto == null)
            {
                return NotFound();
            }

            return messageDto;
        }

        [HttpPut("{id}/Update")]
        public async Task<IActionResult> PutMessage(int id, [Required] MessageDto messageDto)
        {
            if (User.Identity.Name != messageDto.UserName) return BadRequest();
            
            var updated = _messageService.Update(id, messageDto);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();

        }


        [Authorize(Roles = "admin,moderator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var deleted = _messageService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }

            return NoContent();
        } 
    }
}
