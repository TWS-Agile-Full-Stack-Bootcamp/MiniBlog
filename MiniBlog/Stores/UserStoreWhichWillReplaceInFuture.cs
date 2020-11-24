using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server;
using MiniBlog.DTO;

namespace MiniBlog
{
    public class UserStoreWhichWillReplaceInFuture
    {
        static UserStoreWhichWillReplaceInFuture()
        {
            Users = new List<User>();
        }

        public static List<User> Users { get; private set; }

        /// <summary>
        /// This is for test only, please help resolve!
        /// </summary>
        public static void Init()
        {
            Users = new List<User>();
        }
    }
}