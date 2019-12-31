using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAboutProjects.DAL;

namespace ProjectAboutProjects.Controllers
{
    public class UserController : Controller
    {
        private readonly MySqlContext context;

        /*
         *
         * Настройки, роли
         * Авторизация
         * Регистрация
         * Оповещение по почте - самому себе
         * Роли:
         * 1. Нуб юзер без возможностей (тень)
         * 2. Простой юзер (Юзер с возможностью писать комментарии к посту)
         * 3. Админ возможность писать посты и все что ниже
         * 4. Супер админ - Возможность заполнять проекты
         *
         *///

        public UserController(MySqlContext _context)
        {//IHttpActionResult
            //https://docs.microsoft.com/ru-ru/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
            context = _context;
        }

        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return await Settings();
            }
            else
            {
                return await Registration();
            }
        }

        public async Task<ActionResult> Likes()
        {
            return View("Likes");
        }

        public async Task<ActionResult> Settings()
        {
            return View("Settings");
        }

        public async Task<ActionResult> Registration()
        {
            return View("Registration");
        }
    }
}
