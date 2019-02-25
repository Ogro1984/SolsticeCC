using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers
{

    
    //GET Api Retrieve Method


    [Route("api/values")]
    [Produces("application/Json")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
            
            [HttpGet]
            public Items Get()
            {
            return new Items()
            {
                Name = "Thing",
                Weight = 100.5
            };
            }
        




        // GET: api/WebApi
        [HttpGet]
        public IEnumerable<string> Get1()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WebApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WebApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/WebApi/5
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
