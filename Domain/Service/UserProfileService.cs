using System.Collections.Generic;
using Domain.Mapper;
using Model.Dto;
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
            return userProfile != null ? _userProfileMapper.MapToUserProfileDto(userProfile) : null;
        }

        public UserProfileDto CreateUserProfile(UserProfileDto userProfileDto)
        {
            //UserProfile user = new UserProfile() {Email = userProfileDto.Email, UserName = userProfileDto.UserName};
            var userProfile = _userProfileMapper.MapToUserProfile(userProfileDto);

            var createdUserProfile = _userProfileRepository.CreateUserProfile(userProfile, userProfileDto.Password);
            if (createdUserProfile.Result == null)
            {
                return null;
            }
            return _userProfileMapper.MapToUserProfileDto(createdUserProfile.Result);
        }

        public bool Login(UserProfileDto dto)
        {
            var userProfile = _userProfileMapper.MapToUserProfile(dto);
            var loginSuccess = _userProfileRepository.LoginUserProfile(userProfile, dto.Password);
            
            return loginSuccess.Result;
        }

        public void Logout()
        {
            _userProfileRepository.LogoutUserProfile();
        }
    }
}