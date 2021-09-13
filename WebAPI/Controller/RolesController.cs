using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Model;

namespace WebAPI.Controller
{
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    [ApiController]
    public class RolesController: ControllerBase
    {
        private readonly RoleService _roleService;
        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public List<RoleDto> GetAll()
        {
            return _roleService.GetAll();
        }

        [HttpGet("{roleName}")]
        public async Task<ActionResult<RoleDto>> GetRole(string roleName)
        {
            var role = _roleService.GetRole(roleName);
            if (role == null) 
                return NotFound();
            
            return role;
        }
        
        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(RoleDto roleDto)
        {
            if (string.IsNullOrEmpty(roleDto.Name)) return BadRequest();
            
            var createdRole = _roleService.CreateRole(roleDto);
            if (createdRole == null)
                return BadRequest();
            
            return createdRole;
        }
         
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> Delete(string roleName)
        {
            var deleted = _roleService.DeleteRole(roleName);
            if(!deleted)
            {
                return NotFound();
            }
            
            return NoContent();
        } 
    }
}