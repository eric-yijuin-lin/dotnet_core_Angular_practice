using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAppAPI.Data;

namespace PracticeAppAPI.Controllers
{
    [Authorize] // this attribute will protect this controller by applying authrizing mechanism
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var results = await _context.Values.ToListAsync();
            return Ok(results);
        }

        // GET api/values/{id}
        [AllowAnonymous] // the [Authorize] attribute is protecting every action of it, but with this attribute
                         // this action becomes an special case that is allowed to invoke without authorized
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var result = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(result);// the controller returns 204 status code automatically if the result is null
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
