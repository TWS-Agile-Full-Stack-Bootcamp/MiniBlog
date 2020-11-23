using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.DTO;

namespace MiniBlog
{
    public class UserStoreWhichWillReplaceInFuture
    {
        public UserStoreWhichWillReplaceInFuture()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; private set; }
    }
}