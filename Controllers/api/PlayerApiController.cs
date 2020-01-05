using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAboutProjects.Controllers.api
{
    [Route("api/player")]
    [ApiController]
    public class PlayerApiController : ControllerBase
    {

        public PlayerApiController()
        {

        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Если не авторзован возвращать 403
            }
            string stream = (string) jObject["stream"];
            if (stream == null)
            {

            }
            return new JsonResult("qwe");
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Если не авторзован возвращать 403
            }
            string stream = (string)jObject["stream"];
            if (stream == null)
            {

            }
            return new JsonResult("qwe");
        }

        [HttpPost("Get")]
        public async Task<JsonResult> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                //Если не авторзован возвращать 403
            }
            var list = new List<string>()
            {
                "link1","link2"
            };

            return new JsonResult(new JArray(list));
        }
    }
}
