using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Mapper;
using Microsoft.AspNetCore.Identity;
using Model.Dto;
using Model.Model;
using Persistence.Repository;

namespace Domain.Service
{
    public class UserProfileService
    {
        // UserProfileRepository
        
        private readonly UserProfileMapper _userProfileMapper;

        private readonly UserProfileRepository _userProfileRepository;

        public UserProfileService(UserProfileMapper userProfileMapper, UserProfileRepository userProfileRepository)
        {
            _userProfileMapper = userProfileMapper;
            _userProfileRepository = userProfileRepository;
        }
        
        public List<UserProfileDto> GetAll()
        {
            return _userProfileRepository.FindAll()
                .Result
                .ConvertAll(input => _userProfileMapper.MapToUserProfileDto(input));
        }

        public UserProfileDto GetUserProfile(string username)
        {
            var userProfile = _userProfileRepository.FindByUserName(username);

            if (userProfile == null) return null;
            
            var userProfileDto = _userProfileMapper.MapToUserProfileDto(userProfile);
            //userProfileDto.Roles = GetUserRoles(userProfileDto);
            return userProfileDto;
        }

        public UserProfileDto CreateUserProfile(UserProfileRegisterDto registerDto)
        {
            //UserProfile user = new UserProfile() {Email = userProfileDto.Email, UserName = userProfileDto.UserName};
            var userProfile = _userProfileMapper.MapToUserProfileFromRegistration(registerDto);

            var createdUserProfile = _userProfileRepository.CreateUserProfile(userProfile, registerDto.Password);
            if (createdUserProfile.Result == null)
            {
                return null;
            }
            
            return _userProfileMapper.MapToUserProfileDto(createdUserProfile.Result);
        }

        public UserProfileDto Login(LoginUserProfileDto dto)
        {
            var userProfileDto = GetUserProfile(dto.UserName);
            
            var userProfile = _userProfileMapper.MapToUserProfile(userProfileDto);
            var loginSuccess = _userProfileRepository.LoginUserProfile(userProfile, dto.Password);

            return (loginSuccess.Result != null) ? _userProfileMapper.MapToUserProfileDto(loginSuccess.Result) : null;
        }

        public void Logout()
        {
            _userProfileRepository.LogoutUserProfile();
        }

        public Task<IList<string>> GetUserRoles(UserProfile userProfile)
        {
            //var userProfile = _userProfileMapper.MapToUserProfile(userProfileDto);
            return _userProfileRepository.GetUserRoles(userProfile);
        }
        
        public Task<IdentityResult> AddRolesToUser(UserProfile userProfile, IEnumerable<string> roles)
        {
            //var userProfile = _userProfileMapper.MapToUserProfile(userProfileDto);
            return _userProfileRepository.AddRolesToUser(userProfile, roles);
        }
        
        public IdentityResult RemoveRolesFromUser(UserProfileDto userProfileDto, IEnumerable<string> roles)
        {
            var userProfile = _userProfileMapper.MapToUserProfile(userProfileDto);
            return _userProfileRepository.RemoveRolesFromUser(userProfile, roles).Result;
        }
        
        public async Task<bool> ChangeUserRole(string username, List<string> roles)
        {
            
            // UserProfileDto user = GetUserProfile(username);
            // if (user == null) return false;
            // var userProfile = _userProfileMapper.MapToUserProfile(user);

            await _userProfileRepository.ChangeUserRole(username, roles);
            // 
            // var userRoles =  GetUserRoles(userProfile).Result;
            // //var userRoles= await _userManager.GetRolesAsync(userProfile);
            // var addedRoles = roles.Except(userRoles);
            // var removedRoles = userRoles.Except(roles);
            //
            // await AddRolesToUser(userProfile, addedRoles); 
            //
            // //await RemoveRolesFromUser(user, removedRoles);
        
            return true;
        }
    }
}