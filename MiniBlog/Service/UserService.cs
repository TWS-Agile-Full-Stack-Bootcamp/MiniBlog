using System.Collections.Generic;
using System.Linq;
using MiniBlog.DTO;

namespace MiniBlog.Service
{
    public class UserService
    {
        private readonly UserStore userStore;
        public UserService(UserStore userStore)
        {
            this.userStore = userStore;
        }

        public void Register(string userName)
        {
            if (userName != null)
            {
                if (!userStore.Users.Exists(_ => userName == _.Name))
                {
                    userStore.Users.Add(new User(userName));
                }
            }
        }

        public List<User> GetAll()
        {
            return userStore.Users.ToList();
        }
    }
}