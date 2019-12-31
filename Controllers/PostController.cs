using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectAboutProjects.DAL;
using ProjectAboutProjects.Models;

namespace ProjectAboutProjects.Controllers
{
    public class PostController : Controller
    {

        /*
         * Написание постов, и описаний проектов
         * Оставление комментариев к постам и к проектам
         * 
         * Сделать сортировку, по просмотрам и по дате и названию
         * Просмотр постов, краткое руководство
         *
         *
         *///
        private readonly MySqlContext context;

        public PostController(MySqlContext _context)
        {//IHttpActionResult
            //https://docs.microsoft.com/ru-ru/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<ActionResult> Write()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Post()
        {
            //CHECK ID
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Posts()
        {
            var posts = context.Posts.ToList();
            return Json(posts);//View(posts);
        }
    }
}
