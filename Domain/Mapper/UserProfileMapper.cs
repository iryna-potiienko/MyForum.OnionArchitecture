using System.Collections;
using System.Collections.Generic;
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
                Id = userProfile.Id,
                UserName = userProfile.UserName,
                Email = userProfile.Email
            };


            return userProfileDto;
        }

        public UserProfile MapToUserProfile(UserProfileDto userProfileDto)
        {
            var userProfile = new UserProfile()
            {
                Id = userProfileDto.Id,
                UserName = userProfileDto.UserName,
                Email = userProfileDto.Email
            };


            return userProfile;
        }
    }
}