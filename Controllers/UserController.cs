namespace TopCoderStarterApp.Controllers
{
    using TopCoderStarterApp.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class UserController: Controller
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return new ObjectResult(await _repo.GetAllUsers());
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            var user = await _repo.GetUser(id);

            if (user == null)
                return new NotFoundResult();
            
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            user.Id = await _repo.GetNextId();
            await _repo.Create(user);
            return new OkObjectResult(user);
        }

        // PUT api/users/1
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(long id, [FromBody] User user)
        {
            var userFromDb = await _repo.GetUser(id);

            if (userFromDb == null)
                return new NotFoundResult();

            user.Id = userFromDb.Id;
            user.InternalId = userFromDb.InternalId;

            await _repo.Update(user);

            return new OkObjectResult(user);
        }

        // DELETE api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetUser(id);

            if (post == null)
                return new NotFoundResult();

            await _repo.Delete(id);

            return new OkResult();
        }
    }
}