using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void Register(User user)
        {
            if (!UserStoreWhichWillReplaceInFuture.Users.Exists(_ => user.Name == _.Name))
            {
                UserStoreWhichWillReplaceInFuture.Users.Add(user);
            }
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return UserStoreWhichWillReplaceInFuture.Users;
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = UserStoreWhichWillReplaceInFuture.Users.FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = UserStoreWhichWillReplaceInFuture.Users.FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                UserStoreWhichWillReplaceInFuture.Users.Remove(foundUser);
                ArticleStoreWhichWillReplaceInFuture.Articles.RemoveAll(a => a.UserName == foundUser.Name);
            }

            return foundUser;
        }
    }
}