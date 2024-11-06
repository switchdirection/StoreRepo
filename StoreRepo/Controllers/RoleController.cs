using Application.Roles.Services;
using Microsoft.AspNetCore.Mvc;
using Contracts.Roles;
using AutoMapper;
using Domain.Entities;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллр по работе с ролями
    /// </summary>
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(
            IRoleService roleService,
            IMapper mapper
        )
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Roles(CancellationToken cancellation)
        {
            List<ApplicationRole> roles = _roleService.GetAllRoles(cancellation);
            var rolesDto = new List<RoleDto>(roles.Count);
            
            foreach (var role in roles)
            {
                rolesDto.Add(new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }
            
            return View("RoleView", rolesDto);
        }

        [HttpGet]
        public IActionResult Create(CancellationToken cancellation)
        {
            return PartialView("CreateRolePartial");
        }

        [HttpPost]
        public IActionResult Create(string roleName, CancellationToken cancellation) 
        {
            _roleService.AddRole(roleName);
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellation)
        {
            await _roleService.DeleteRole(id, cancellation);
            return RedirectToAction("Roles");
        }
    }
}
