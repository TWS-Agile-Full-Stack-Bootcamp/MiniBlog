using System.Collections.Generic;
using System.Linq;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service
{
    public class UserService
    {
        private readonly UserStoreWhichWillReplaceInFuture userStore;

        public UserService(UserStoreWhichWillReplaceInFuture userStore)
        {
            this.userStore = userStore;
        }

        public virtual void Register(User user)
        {
            if (user != null)
            {
                if (!userStore.Users.Exists(_ => user.Name == _.Name))
                {
                    userStore.Users.Add(user);
                }
            }
        }

        public List<User> GetAll()
        {
            return userStore.Users.ToList();
        }

        public User Update(User user)
        {
            var foundUser = FindByName(user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        public User FindByName(string userName)
        {
            var foundUser = this.userStore.Users.FirstOrDefault(_ => _.Name == userName);
            return foundUser;
        }

        public void DeleteByName(string name)
        {
            var foundUser = this.FindByName(name);
            this.userStore.Users.Remove(foundUser);
        }

        public User GetByName(string name)
        {
            return this.userStore.Users.FirstOrDefault(user => user.Name == name);
        }
    }
}