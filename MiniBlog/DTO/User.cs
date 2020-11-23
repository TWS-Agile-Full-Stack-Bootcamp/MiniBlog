using System.Collections.Generic;
using Newtonsoft.Json;

namespace MiniBlog.DTO
{
    public class User
    {
        public User()
        {
        }

        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}