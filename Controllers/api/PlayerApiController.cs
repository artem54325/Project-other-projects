using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectAboutProjects.Controllers.api
{
    [Route("api/player")]
    [ApiController]
    public class PlayerApiController : ControllerBase
    {
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
            return null;
        }

        [HttpPost("Get")]
        public async Task<JsonResult> Get([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Если не авторзован возвращать 403
            }
            string stream = (string) jObject["stream"];
            if (stream == null)
            {

            }
            return null;
        }
    }
}
