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
        /// <summary>
        /// Метод контроллера для перехода на страницу с отображением всех ролей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public IActionResult Roles(string searchQuery, CancellationToken cancellation)
        {
            var roles = _roleService.GetAllRolesAsync(cancellation);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                roles = roles.Where(r => r.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View("RoleView", roles);
        }
        /// <summary>
        /// Метод контроллера перенаправляющий на страницу для добавления роли
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public IActionResult Create(CancellationToken cancellation)
        {
            return PartialView("CreateRolePartial");
        }
        /// <summary>
        /// Метод контроллера для создания новой роли
        /// </summary>
        /// <param name="roleName">Название роли</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Create(string roleName, CancellationToken cancellation) 
        {
            await _roleService.AddRoleAsync(roleName);
            return RedirectToAction("Roles");
        }

        /// <summary>
        /// Метод контроллера для удаления роли
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellation)
        {
            await _roleService.DeleteRoleAsync(id, cancellation);
            return RedirectToAction("Roles");
        }
    }
}
