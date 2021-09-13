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

        public RoleService(RoleMapper roleMapper, RoleRepository roleRepository)
        {
            _roleMapper = roleMapper;
            _roleRepository = roleRepository;
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
            return role == null ? null : _roleMapper.MapToRoleDto(role);
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

        public bool DeleteRole(string roleName)
        {
            return _roleRepository.Delete(roleName).Result;
        }
    }
}