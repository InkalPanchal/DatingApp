using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _Context;

        public UsersController(DataContext context)
        {
            _Context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            var users = await _Context.Users.ToListAsync();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest("Data not found!!");
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _Context.Users.FindAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else return BadRequest("Data not found!!");
        }

        //// POST api/<UsersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
