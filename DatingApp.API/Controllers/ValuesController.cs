using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")] // attribute based routing
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext Context;

        public ValuesController(DataContext context)
        {
            Context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues() //IActionResult as opposed to ActionResult<> allows us to return HTTP res's (ex. Ok())
        {
            var values = await Context.Values.ToListAsync(); // Retrieve the data from the Values table as a List

            return Ok(values); // Return the values to the client along with a HTTP 200 OK respsonse
        }

        // GET api/values/5
        [HttpGet("{id}")] // Root parameter (after the last '/', in this case 5)
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await Context.Values.FirstOrDefaultAsync(x => x.Id == id); // Returns the first element x of a sequence where x.Id == id argument.
                                                                                   // or the type default value if the sequence contains no elements.

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}