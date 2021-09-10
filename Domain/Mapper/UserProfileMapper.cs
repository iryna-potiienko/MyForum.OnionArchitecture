using Model.Dto;
using Model.Model;

namespace Domain.Mapper
{
    public class UserProfileMapper
    {
        public UserProfileDto MapToUserProfileDto(UserProfile userProfile)
        {
            var userProfileDto = new UserProfileDto()
            {
                UserName = userProfile.UserName,
                Email = userProfile.Email
                //Password
            };


            return userProfileDto;
        }

        public UserProfile MapToUserProfile(UserProfileDto userProfileDto)
        {
            var userProfile = new UserProfile()
            {
                UserName = userProfileDto.UserName,
                Email = userProfileDto.Email,
                //PasswordHash = userProfileDto.Password
                
            };


            return userProfile;
        }
    }
}