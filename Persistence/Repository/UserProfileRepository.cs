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
            var userProfile = _userManager.Users.FirstOrDefault(u => u.UserName == username);
            return userProfile;
        }

        public async Task<UserProfile> CreateUserProfile(UserProfile userProfile, string password)
        {
            var result = await _userManager.CreateAsync(userProfile, password);
            if (!result.Succeeded) 
                return null;
            await _signInManager.SignInAsync(userProfile, false);
            return userProfile;

        }

        public async Task<bool> LoginUserProfile(UserProfile userProfile, string password)
        {
            var result =
                await _signInManager
                    .PasswordSignInAsync(userProfile.UserName, password, false, false);
            
            return result.Succeeded;
        }

        public async void LogoutUserProfile()
        {
            await _signInManager.SignOutAsync();
        }
    }
}