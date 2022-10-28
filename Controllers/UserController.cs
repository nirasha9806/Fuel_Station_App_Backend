using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = userService.Get(id);

            if(user == null){
                return NotFound($"User with Id = {id} not found");
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
             userService.Create(user);

             return CreatedAtAction(nameof(Get), new {id = user.id}, user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
             var existingUser = userService.Get(id);

             if(existingUser == null){
                return NotFound($"User with Id = {id} not found");
             }

             userService.Update(id,user);

             return NoContent();
        }

         [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
             var existingUser = userService.Get(id);

             if(existingUser == null){
                return NotFound($"User with Id = {id} not found");
             }

             userService.Remove(id);

             return Ok($"User with Id = {id} deleted");
        }

        [HttpGet("login")]
        public ActionResult<User> Login(string username, string password)
        {
            var user = userService.Login(username, password);

            if(user == null){
                return NotFound($"User with username = {username} not found");
            }

            if(user.Password != password){
                return NotFound($"Username and Passowrd is not matching");
            }

            return user;
        }
    }
}