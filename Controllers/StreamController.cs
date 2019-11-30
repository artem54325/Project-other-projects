using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAboutProjects.Controllers
{
    public class StreamController : Controller
    {
        /*
         *
         * Удалить, Все это перенести в плеер
         *
         *///
        public async Task<ActionResult> Index()
        {
            return View();
        }

    }
}
