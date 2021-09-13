using Microsoft.AspNetCore.Identity;
using Model.Dto;

namespace Domain.Mapper
{
    public class RoleMapper
    {
        public RoleDto MapToRoleDto(IdentityRole role)
        {
            var roleDto = new RoleDto()
            {
                Name = role.Name
            };
            
            return roleDto;
        }

        public IdentityRole MapToRole(RoleDto roleDto)
        {
            var role = new IdentityRole()
            {
                Name = roleDto.Name
            };
            
            return role;
        }
    }
}