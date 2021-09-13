using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Model;

namespace WebAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;

        public ProfileController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserProfileDto dto)
        {
            var created = _userProfileService.CreateUserProfile(dto);

            if (created == null)
            {
                return Unauthorized();
            }

            return CreatedAtAction("GetUser", new {username = created.UserName}, created);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserProfileDto dto)
        {
            var loginSuccess = _userProfileService.Login(dto);
            
            if (loginSuccess)
            {
                return CreatedAtAction("GetUser", new {username = dto.Email}, dto);
            }
            
            return Unauthorized();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            _userProfileService.Logout();
            return Ok();
        }
        
        [HttpGet("List")]
        public List<UserProfileDto> GetAll()
        {
            return _userProfileService.GetAll();
        }
        
        [HttpGet("{username}/FindUserByUserName")]
        public async Task<ActionResult<UserProfileDto>> GetUser([Required] string username)
        {
            var userDto = _userProfileService.GetUserProfile(username);
            if (userDto == null)
            {
                return NotFound();
            }
        
            return userDto;
        }

        [HttpPost("ChangeRole/{username}")]
        public async Task<IActionResult> ChangeUserRole(string username, List<string> userRoles)
        {
            var result = await _userProfileService.ChangeUserRole(username, userRoles);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}