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
        public async Task<ActionResult> Posts()
        {
            var posts = context.Posts.ToList();
            return View(posts);
        }

        [HttpGet(Name ="post/{id}")]
        public async Task<ActionResult> Post(string id)
        {
            var post = context.Posts.Where(a => a.Id.Equals(id)).SingleOrDefault();
            if(post == null)
            {
                return Redirect("/Post");
            }
            post.Views += 1;
            context.Posts.Update(post);
            ViewBag.post = JsonConvert.SerializeObject(post);
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> PostLike([FromBody] JObject jObject)
        {
            try
            {
                string postId = jObject["postId"] == null ? null : jObject["postId"].ToString();
                var post = context.Posts.Where(a => a.Id.Equals(postId)).SingleOrDefault();

                bool activiti = false;
                if (post.UsersLike.Contains(User.Identity.Name))
                {
                    post.UsersLike.Remove(User.Identity.Name);
                    activiti = false;
                }
                else
                {
                    post.UsersLike.Add(User.Identity.Name);
                    activiti = true;
                }

                context.Posts.Add(post);
                context.SaveChangesAsync();
                //context.SaveChanges();

                return Json("{'status':true, 'activiti':" + activiti + "}");
            }
            catch (Exception e)
            {
                return Json("{'status':false, 'error':'Error: " + e.Message + "'}");
            }
        }

        [HttpPost]
        public async Task<JsonResult> CommentLike([FromBody] JObject jObject)
        {
            try
            {
                string comId = jObject["commentId"] == null ? null : jObject["commentId"].ToString();
                var com = context.Comments.Where(a => a.Id.Equals(comId)).SingleOrDefault();

                bool activiti = false;
                if (com.UsersLike.Contains(User.Identity.Name))
                {
                    com.UsersLike.Remove(User.Identity.Name);
                    activiti = false;
                }
                else
                {
                    com.UsersLike.Add(User.Identity.Name);
                    activiti = true;
                }

                context.Comments.Add(com);
                context.SaveChangesAsync();
                //context.SaveChanges();
                return Json("{'status':true, 'activiti':"+ activiti + "}");
            }
            catch (Exception e)
            {
                return Json("{'status':false, 'error':'Error: " + e.Message + "'}");
            }
        }

        [HttpPost]
        public async Task<JsonResult> WritePost([FromBody] JObject jObject)
        {
            try
            {
                Console.WriteLine("Jboqe = " + jObject.ToString());
                Post post = new Post()
                {
                    Views = 0,
                    UserId = User.Identity.Name,
                    Html = jObject["html"] == null ? null : jObject["html"].ToString(),
                    ShortDescription = jObject["shortDescription"] == null ? null : jObject["shortDescription"].ToString(),
                    Lang = jObject["lang"] == null ? null : jObject["lang"].ToString(),
                    Comments = new System.Collections.Generic.List<Comment>(),
                    DateTimePublish = new DateTime()
                };
                context.Posts.Add(post);
                context.SaveChangesAsync();
                //context.SaveChanges();
            }
            catch (Exception e)
            {
                return Json("{'status':false, 'error':'Error: "+e.Message+"'}");
            }

            return Json("{'status':true}");
        }

        [HttpPost]
        public async Task<JsonResult> WriteComment([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            try
            {
                string postId = jObject["postId"] == null ? null : jObject["postId"].ToString();
                Comment comment = new Comment()
                {
                    UserId = User.Identity.Name,
                    DateTimePublish = new DateTime(),
                    Html = jObject["html"] == null ? null : jObject["html"].ToString()
                };
                var post = context.Posts.Where(a => a.Id.Equals(postId)).SingleOrDefault();
                post.Comments.Add(comment);

                context.Posts.Update(post);
                context.Comments.Add(comment);
                context.SaveChangesAsync();
                //context.SaveChanges();
            }
            catch (Exception e)
            {
                return Json("{'status':false, 'error':'Error: " + e.Message + "'}");
            }

            return Json("{'status':true}");
        }
    }
}
