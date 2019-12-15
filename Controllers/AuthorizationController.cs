using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAboutProjects.DAL;
using ProjectAboutProjects.Models;

namespace ProjectAboutProjects.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly MySqlContext context;

        public AuthorizationController(MySqlContext _context)
        {
            context = _context;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<string> Registration(RegisterModel model)
        {
            //if (ModelState.IsValid)
            //{
                User user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    context.Users.Add(new User { Email = model.Email, Password = model.Password });
                    await context.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return "{status:true, error:'authorization'}";
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}
            return "{status:false, error:'registration'}";
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<string> Authorization(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //User user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            User user = new User()
            {
                Email = "Email",
                Password = "qwe",
                LastName = "qwe"
            };
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return "{status:true}";
                }
            //}
            return "{status:false, error:'authorization'}";

        }

        [HttpPost]
        public async Task<string> Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return "{status:true}";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> ChangePassword()
        {
            return null;
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}