using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ProjectAboutProjects.Controllers.University
{
    [Route("University")]
    public class QuestionsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //добавить в хедер никнайм чувака которой проходит опрос
            return null;
        }

        [HttpGet("Admin")]
        public async Task<ActionResult> Admin()
        {
            //добавить в хедер никнайм чувака которой проходит опрос
            return null;
        }

        [HttpGet("CreateQuestions")]
        public async Task<ActionResult> CreateQuestions()
        {
            //добавить в хедер никнайм чувака которой проходит опрос
            return null;
        }

        [HttpPost("CreateQuestion")]
        public async Task<ActionResult> CreateQuestion([FromBody] JObject jObject)
        {
            //добавить в хедер никнайм чувака которой проходит опрос
            return null;
        }

        [HttpPost("authName")]
        public async Task<ActionResult> AuthQuestions()
        {
            //добавить в хедер никнайм чувака которой проходит опрос
            return null;
        }

        [HttpGet("Questions")]
        public async Task<ActionResult> GetQuestions()
        {
            //Добавить эти вопросы в опрос 
            return null;
        }

        [HttpGet("Result")]
        public async Task<ActionResult> GetResult([FromBody] JObject jObject)
        {
            //Добавить проверку результатов  
            return null;
        }
    }
}
