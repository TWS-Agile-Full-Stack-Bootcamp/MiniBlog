using System.Collections.Generic;
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
    }
}