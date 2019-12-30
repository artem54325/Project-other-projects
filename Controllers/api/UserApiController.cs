using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ProjectAboutProjects.Controllers.api
{
    [Route("api/User")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> Settings()
        {
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> Settings([FromBody] JObject jObject)
        {
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> GetUser([FromBody] string username)
        {
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll()
        {
            return null;
        }
    }
}
