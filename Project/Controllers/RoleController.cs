using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.API;
using Model.API;
using System.Collections;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        protected IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpPost]
        [Route("AddRoles")]
        [Produces(typeof(Role))]
        public IActionResult AddStudent(Role roles)
        {
            Role role = _roleServices.AddRole(roles);
            return Ok(role);
        }

        [HttpGet]
        [Route("GetRoles")]
        [Produces(typeof(IEnumerable<Role>))]
        public async Task<IActionResult> GetStudents()
        {
            IEnumerable<Role> roles = await _roleServices.GetRoles();
            return Ok(roles);
        }

        [HttpPut]
        [Route("UpdateRole{Id}")]
        public async Task<IActionResult> UpdateRole(int Id, Role role)
        {
            if(Id != null)
            {
                Role roles = await _roleServices.UpdateRole(role);
                return Ok(roles);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteRole{Id}")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            var deleteRole = await _roleServices.GetRoleById(Id);
            if(deleteRole != null)
            {
               await _roleServices.DeleteRole(Id);
                return Ok(deleteRole);
            }
            return NotFound();
        }
    }
}
