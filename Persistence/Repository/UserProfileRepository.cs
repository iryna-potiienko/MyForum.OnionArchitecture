using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Repository
{
    //todo
    public class UserProfileRepository
    {
        private readonly UserManager<UserProfile> _userManager;
        private readonly SignInManager<UserProfile> _signInManager;
 
        public UserProfileRepository(UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<List<UserProfile>> FindAll()
        {
            return _userManager.Users.ToListAsync();
        }
        
        public UserProfile FindByUserName(string username)
        {
            return _userManager.Users.FirstOrDefault(u => u.UserName == username);
        }

        public async Task<UserProfile> CreateUserProfile(UserProfile userProfile, string password)
        {
            var result = await _userManager.CreateAsync(userProfile, password);
            
            if (!result.Succeeded) 
                return null;

            if (!AddUserRoleToUserProfile(userProfile).Result)
            {
                return null;
            }
            
            await _signInManager.SignInAsync(userProfile, false);
            return userProfile;

        }

        public async Task<UserProfile> LoginUserProfile(UserProfile userProfile, string password)
        {
            var result =
                await _signInManager
                    .PasswordSignInAsync(userProfile.UserName, password, false, false);

            return result.Succeeded ? userProfile : null;
        }

        public async void LogoutUserProfile()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> AddUserRoleToUserProfile(UserProfile userProfile)
        {
            var result = await _userManager.AddToRoleAsync(userProfile, "user");
            return result.Succeeded;
        }
        
        public  Task<IList<string>> GetUserRoles(UserProfile userProfile)
        {
            var roles =  _userManager.GetRolesAsync(userProfile);
            return roles;
        }
        
        public  Task<IdentityResult> AddRolesToUser(UserProfile userProfile, IEnumerable<string> roles)
        {
            return  _userManager.AddToRolesAsync(userProfile, roles);
        }
        
        public async Task<IdentityResult> RemoveRolesFromUser(UserProfile userProfile, IEnumerable<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(userProfile, roles);
        }

        public async Task<bool> ChangeUserRole(string username, List<string> roles)
        {
            UserProfile user = FindByUserName(username);
            if (user == null) return false;
            
            var userRoles = await _userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
        
            await _userManager.AddToRolesAsync(user, addedRoles);
        
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
        
            return true;
        }
    }
}