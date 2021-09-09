using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using MyForum.Models;
using Persistence;

namespace WebAPI.Controller
{
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
            
            return CreatedAtAction("GetMessage", new { id = created.Id }, created);
        }
        
        [HttpGet("List")]
        public List<MessageDto> GetAll()
        {
            return _messageService.GetAll();
        }
        
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
            var updated = _messageService.Update(id, messageDto);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();
        }


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
