using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Services;
using FlyboMovie.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class LoginModel : PageModel
    {
        private IUserService _userService;

        [BindProperty]
        public LoginViewModel ViewModel { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByAccount(ViewModel.Account);
                if (user == null)
                {
                    ModelState.AddModelError("Account", "用户名不存在");
                    return Page();
                }
                if (user.Password != ViewModel.Password)
                {
                    ModelState.AddModelError("Password", "密码错误");
                    return Page();
                }
                var userRoles = _userService.GetUserRolesByUserId(user.Id);
                var principal = _userService.BuildPrincipal(user, userRoles);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = true,
                    });
                return RedirectToPage(returnUrl);
            }
            return Page();
        }
    }
}