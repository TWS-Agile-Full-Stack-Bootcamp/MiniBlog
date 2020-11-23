using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.DTO;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ArticleService articleService;
        private readonly UserService userService;

        public UserController(ArticleService articleService, UserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }

        [HttpPost]
        public void Register(User user)
        {
            this.userService.Register(user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = userService.Update(user);

            return foundUser;
        }

        [HttpDelete]
        public void Delete(string name)
        {
            userService.DeleteByName(name);
            articleService.RemoveByUserName(name);
        }
    }
}