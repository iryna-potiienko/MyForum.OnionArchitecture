using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Model;
using Persistence.Repository;

namespace Domain.Service
{
    public class RoleService
    {
        private readonly RoleMapper _roleMapper;

        private readonly RoleRepository _roleRepository;
        
        private readonly UserProfileService _userProfileService;

        public RoleService(RoleMapper roleMapper, RoleRepository roleRepository, UserProfileService userProfileService)
        {
            _roleMapper = roleMapper;
            _roleRepository = roleRepository;
            _userProfileService = userProfileService;
        }
        
        public List<RoleDto> GetAll()
        {
            return _roleRepository.FindAll()
                .Result
                .ConvertAll(input => _roleMapper.MapToRoleDto(input));
        }

        public RoleDto GetRole(string roleName)
        {
            var role = _roleRepository.FindByRoleName(roleName).Result;
            return _roleMapper.MapToRoleDto(role);
        }

        public RoleDto CreateRole(RoleDto roleDto)
        {
            var role = _roleMapper.MapToRole(roleDto);

            var createdRole = _roleRepository.CreateRole(role);
            if (createdRole.Result == null)
            {
                return null;
            }
            return _roleMapper.MapToRoleDto(createdRole.Result);
        }
        
        // public bool ChangeUserRole(string username, List<string> roles)
        // {
        //     // получаем пользователя
        //     //UserProfile user = _userManager.Users.FirstOrDefault(u => u.UserName == username);
        //     UserProfileDto user = _userProfileService.GetUserProfile(username);
        //     if (user == null) return false;
        //     
        //     // получем список ролей пользователя
        //     var userRoles = _userProfileService.GetUserRoles(user);//await _userManager.GetRolesAsync(user);
        //     // получаем все роли
        //     //var allRoles = _roleManager.Roles.ToList();
        //     // получаем список ролей, которые были добавлены
        //     var addedRoles = roles.Except(userRoles);
        //     // получаем роли, которые были удалены
        //     var removedRoles = userRoles.Except(roles);
        //
        //     _userProfileService.AddRolesToUser(user, addedRoles); //await _userManager.AddToRolesAsync(user, addedRoles);
        //
        //     _userProfileService.RemoveRolesFromUser(user, removedRoles);//await _userManager.RemoveFromRolesAsync(user, removedRoles);
        //
        //     return true;
        // }
    }
}