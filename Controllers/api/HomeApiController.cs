using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAboutProjects.Controllers.api
{
    [Route("api/home")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        // GET: api/HomeApi
        [HttpGet("get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HomeApi/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/HomeApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HomeApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
