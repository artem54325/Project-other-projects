using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAboutProjects.DAL;
using ProjectAboutProjects.Models;

namespace ProjectAboutProjects.Controllers
{
    public class PlayerController : Controller
    {
        private readonly MySqlContext context;
        /*
        Тут должна быть плеер с плейлистами
        Создание групповых чатов, с рисованием
        Отправка приглашения, копирование приглашениия
        *///

        public PlayerController(MySqlContext _context)
        {//IHttpActionResult
            //https://docs.microsoft.com/ru-ru/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
            context = _context;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Stream()
        {
            return View("ExampleStream");
        }
    }
}
