using Application.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Метод контроллера перенаправляющий на страницу с отображением всех зарегистрированных пользователей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> ShowUsers(CancellationToken cancellation)
        {
            var usersDto = await _userService.GetAllUsersAsync(cancellation);
            return View("UsersView", usersDto);
        }
        /// <summary>
        /// Метод контроллера для добавления нового пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel user, CancellationToken cancellation)
        {
            try
            {
                IdentityResult result;
                if (user.PhoneNumber == null)
                    result = await _userService.AddUserAsync(user.Name, user.Email, user.Password, cancellation);
                else
                    result = await _userService.AddUserAsync(user.Name, user.Email, user.Password, user.PhoneNumber, cancellation);
                
                if (result.Succeeded)
                {
                    TempData["UserAddedSuccess"] = "Пользователь успешно добавлен";
                }
                else
                {
                    TempData["UserAddedError"] = "Пользователь не был добавлен";
                }
                return RedirectToAction("ShowUsers");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        /// <summary>
        /// Метод контроллера для редактирования пользователя
        /// </summary>
        /// <param name="model">Модель для редактирования пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Edit (UserEditModel model, CancellationToken cancellation)
        {
            
                IdentityResult result = new IdentityResult();
                if(model.PhoneNumber == "")
                {
                    try
                    {
                        result = await _userService.EditUserAsync(model.Id, model.Name, model.Email, model.Roles, cancellation);
                    }
                    catch (Exception ex) 
                    {
                        ModelState.AddModelError(ex.Source, ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        result = await _userService.EditUserAsync(model.Id, model.Name, model.Email, model.PhoneNumber, model.Roles, cancellation);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(ex.Source, ex.Message);
                    }
                }

                if (result.Succeeded)
                {
                    TempData["UserEditedSuccess"] = "Пользователь успешно отредактирован";
                }
                else
                {
                    TempData["UserEditedError"] = "Пользователь не был отредактирован";
                    ModelState.AddModelError("", "Ошибка при обновлении пользователя");
                }
                return RedirectToAction("ShowUsers");
           
        }

        /// <summary>
        /// Метод контроллера для удаления пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Delete(int userId, CancellationToken cancellation) 
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (result.Succeeded)
            {
                TempData["UserDeletedSuccess"] = "Пользователь успешно удалён";
            }
            else
            {
                TempData["UserDeletedError"] = "Пользователь не был удалён";
            }
            return RedirectToAction("ShowUsers"); 
        }
    }
}
