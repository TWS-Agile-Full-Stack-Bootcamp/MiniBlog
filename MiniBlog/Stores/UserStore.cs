using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.DTO;

namespace MiniBlog
{
    public class UserStore
    {
        public UserStore()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; private set; }

        public void Init()
        {
            Users = new List<User>();
        }
    }
}