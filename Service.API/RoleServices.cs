using System;
using Database.API;
using Model.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(int Id);
        Task<bool> DeleteRole(int Id);
        Task<Role> UpdateRole(Role role);
        Role AddRole(Role role);

    }
    public class RoleServices : IRoleServices
    {
        private readonly Database.API.Repository.IRoleRepository _roleRepository;

        public RoleServices(Database.API.Repository.IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role AddRole(Role role)
        {
            _roleRepository.Add(role);
            return role;
        }

        public async Task<bool> DeleteRole(int Id)
        {
            Role role = await GetRoleById(Id);
            if(role != null)
            {
                _roleRepository.Delete(role);
                return true;
            }
            return false;
        }

        public async Task<Role> GetRoleById(int Id)
        {
            return await _roleRepository.GetById(Id);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _roleRepository.GetAll();
        }

        public async Task<Role> UpdateRole(Role role)
        {
            Role roles = await GetRoleById(role.Id);
            if(roles != null)
            {
                Role role1 = new Role();
                role1.Name = role.Name;
                _roleRepository.Update(role1);
                return roles;
            }
            return role;
        }
    }
}
