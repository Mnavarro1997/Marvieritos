using MarvieritosApp.DataBase;
using MarvieritosApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MarvieritosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EcommerceDb _ecommerceDb;

        public UsersController(EcommerceDb ecommerceDb)
        {
            _ecommerceDb = ecommerceDb;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            if (_ecommerceDb.User.Any())
                return Ok(_ecommerceDb.User);
            else
                return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            if (!_ecommerceDb.User.Any(p => p.Id_usuario == user.Id_usuario))
            {
                _ecommerceDb.User.Add(user);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Exists a user with id{user.Id_usuario}");
            }
        }

        // PUT api/<UsersController>/userId
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (_ecommerceDb.User.Any(p => p.Id_usuario == id))
            {
                var UserToUpdate = _ecommerceDb.User.Single(p => p.Id_usuario == id);
                _ecommerceDb.User.Remove(UserToUpdate);
                _ecommerceDb.User.Add(user);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a user with id {id}");
            }
        }

        // DELETE api/<UsersController>/productId
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_ecommerceDb.User.Any(p => p.Id_usuario == id))
            {
                var UserToDelete = _ecommerceDb.User.Single(p => p.Id_usuario == id);
                _ecommerceDb.User.Remove(UserToDelete);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a user with id {id}");
            }
        }
    }
}
