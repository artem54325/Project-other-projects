using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAboutProjects.Controllers
{
    public class VideoCallController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View("WebRTC");
        }
        public async Task<ActionResult> WebRTC()
        {
            return View();
        }
    }
}
