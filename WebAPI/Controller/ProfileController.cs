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
        private readonly UserManager<UserProfile> _userManager;
        private readonly SignInManager<UserProfile> _signInManager;
 
        private readonly UserProfileService _userProfileService;

        public ProfileController(UserProfileService userProfileService,UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            _userProfileService = userProfileService;
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}