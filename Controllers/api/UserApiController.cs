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
        public UserApiController()
        {

        }
        [HttpPost("Password")]
        public async Task<JsonResult> Password([FromBody] JObject jObject)
        {
            return null;
        }

        [HttpGet("Settings")]
        public async Task<JsonResult> Settings()
        {

            return null;
        }

        [HttpPost("Settings")]
        public async Task<JsonResult> Settings([FromBody] JObject jObject)
        {
            return null;
        }
    }
}
