using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Posts()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Post()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> WritePost()
        {
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> WriteComment()
        {
            return null;
        }
    }
}
