using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.Model;
using MiniBlog.Service;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly ArticleService articleService;

        public UserController(UserService userService, ArticleService articleService)
        {
            this.userService = userService;
            this.articleService = articleService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            this.userService.Register(user);
            return CreatedAtAction(nameof(GetByName), new { name = user.Name }, user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return this.userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = this.userService.Update(user);

            return foundUser;
        }

        [HttpDelete]
        public void Delete(string name)
        {
            this.userService.DeleteByName(name);
            this.articleService.RemoveByUserName(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return this.userService.GetByName(name);
        }
    }
}