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
    public class HomeController : Controller
    {
        private readonly MySqlContext context;

        public HomeController(MySqlContext _context)
        {//IHttpActionResult
            //https://docs.microsoft.com/ru-ru/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
            context = _context;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            //HttpContext.Response.Cookies["lang"].Value = "en";
            HttpContext.Response.Cookies.Append("lang", "en");

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";
            HttpContext.Response.Cookies.Append("lang", "tr");

            return View();
        }

        public async Task<ActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
