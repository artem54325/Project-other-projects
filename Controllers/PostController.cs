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
        [HttpGet(Name ="write")]
        public async Task<ActionResult> Write()
        {
            return View();
        }
    }
}
