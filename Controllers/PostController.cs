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
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
