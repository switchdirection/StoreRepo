using Application.Users;
using Contracts.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;

namespace StoreRepo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowUsers(CancellationToken cancellation)
        {
            var usersDto = await _userService.GetAllUsersAsync(cancellation);
            return View("UsersView", usersDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel user, CancellationToken cancellation)
        {
            try
            {
                IdentityResult result;
                if (user.PhoneNumber == null)
                    result = await _userService.AddUser(user.Name, user.Email, user.Password, cancellation);
                else
                    result = await _userService.AddUser(user.Name, user.Email, user.Password, user.PhoneNumber, cancellation);
                
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

        [HttpPost]
        public async Task<IActionResult> Edit (UserEditModel model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = new IdentityResult();
                if(model.PhoneNumber == "")
                {
                    try
                    {
                        result = await _userService.EditUser(model.Id, model.Name, model.Email, model.Roles, cancellation);
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
                        result = await _userService.EditUser(model.Id, model.Name, model.Email, model.PhoneNumber, model.Roles, cancellation);
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

            return View(model);
        }

        public async Task<IActionResult> Delete(int userId, CancellationToken cancellation) 
        {
            var result = await _userService.DeleteUser(userId);
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
