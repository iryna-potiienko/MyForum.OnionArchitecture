using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Repository
{
    public class RoleRepository
    {
        RoleManager<IdentityRole> _roleManager;
        
        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> FindAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> FindByRoleName(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }
        
        public async Task<IdentityRole> CreateRole(IdentityRole role)
        {
            if (string.IsNullOrEmpty(role.Name)) return null;

            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded ? role : null;
        }

        public async Task<bool> Delete(string roleName)
        {
            IdentityRole role = FindByRoleName(roleName).Result;
            if (role == null) return false;
            IdentityResult result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;

        }

        // public void GetUserRoles()
        // {
        //     _userManager.GetRolesAsync(user);
        // }
        
       // public async Task<IActionResult> ChangeUserRole(string username, List<string> roles)
       //  {
       //      // получаем пользователя
       //      UserProfile user = _userManager.Users.FirstOrDefault(u => u.UserName == username);
       //      if (user == null) return NotFound();
       //      
       //      // получем список ролей пользователя
       //      var userRoles = await _userManager.GetRolesAsync(user);
       //      // получаем все роли
       //      var allRoles = _roleManager.Roles.ToList();
       //      // получаем список ролей, которые были добавлены
       //      var addedRoles = roles.Except(userRoles);
       //      // получаем роли, которые были удалены
       //      var removedRoles = userRoles.Except(roles);
       //  
       //      await _userManager.AddToRolesAsync(user, addedRoles);
       //  
       //      await _userManager.RemoveFromRolesAsync(user, removedRoles);
       //  
       //      //return RedirectToAction("UserList");
       //      //return CreatedAtAction("GetChapter", new { id = created.Id }, created);
       //      return Ok();
       //      //return CreatedAtAction("GetAll","Profile",new{});
       //  }
    }
}