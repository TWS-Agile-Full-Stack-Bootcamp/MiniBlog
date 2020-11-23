using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.DTO;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void Register(User user)
        {
            if (!UserStore.Users.Exists(_ => user.Name == _.Name))
            {
                UserStore.Users.Add(user);
            }
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return UserStore.Users;
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = UserStore.Users.FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = UserStore.Users.FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                UserStore.Users.Remove(foundUser);
                ArticleStore.Articles.RemoveAll(a => a.UserName == foundUser.Name);
            }

            return foundUser;
        }
    }
}