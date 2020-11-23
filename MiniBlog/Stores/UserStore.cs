using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.DTO;

namespace MiniBlog
{
    public abstract class UserStore
    {
        static UserStore()
        {
            Users = new List<User>();
        }

        public static List<User> Users { get; private set; }
    }
}