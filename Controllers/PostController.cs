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

        [HttpGet]
        public async Task<JsonResult>Search(string id)
        {
            //var post = context.Posts.Where(a => a.Id.Equals(id)).SingleOrDefault();
            //if (post == null)
            //{
            //    return null;
            //}
            //post.Views += 1;
            //context.Posts.Update(post);
            //return Json(post);

            //Добавить кол-во просмотров и кол-во лайков
            var post = new Post()
            {
                Html = "qweqeqejnfsdjfnsf\nsdfsfd`sdfsf\nsdf`sdfsfs\n\n\n    qweq\n\nqweq\n\n![qweqweqeqe][1]\n\n**qwe**\n\n*qfdsfs*\n\n  [1]:  https://media.geeksforgeeks.org/wp-content/uploads/20190719161521/core.jpg",
                Lang = "rus",
                ShortDescription = "eeksforgeeks.org/wp-content/uploads/20190719161521/core.jpg",
                PostName = "NAME",
                Views = 9,
                UsersLike = new System.Collections.Generic.List<string> { "qwe", "qweew" },
                Comments = new System.Collections.Generic.List<Comment>
                {
                    new Comment()
                    {
                         Html = "qweqeqksfdmfkfmekf",
                         UsersLike = new System.Collections.Generic.List<string> { "qwe", "qweew" }

                    },
                    new Comment()
                    {
                         Html = "1123211qweqeqwe",
                         UsersLike = new System.Collections.Generic.List<string> { "qwe", "qweew", "qweew" }

                    }

                }
            };
            return new JsonResult(post);
        }

        [HttpPost]
        public async Task<JsonResult> PostLike([FromBody] JObject jObject)
        {
            try
            {
                string postId = jObject["post_id"] == null ? null : jObject["post_id"].ToString();
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
                string comId = jObject["comment_id"] == null ? null : jObject["comment_id"].ToString();
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
                Console.WriteLine("json = " + jObject.ToString());
                Post post = new Post()
                {
                    Views = 0,
                    UserId = User.Identity.Name,
                    PostName = jObject["name_post"] == null ? null : jObject["name_post"].ToString(),
                    Html = jObject["html"] == null ? null : jObject["html"].ToString(),
                    ShortDescription = jObject["short_description"] == null ? null : jObject["short_description"].ToString(),
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
                string postId = jObject["post_id"] == null ? null : jObject["post_id"].ToString();
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
