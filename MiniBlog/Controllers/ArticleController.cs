using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniBlog.DTO;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public List<Article> List()
        {
            return ArticleStore.Articles.ToList();
        }

        [HttpPost]
        public void Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!UserStore.Users.Exists(_ => article.UserName == _.Name))
                {
                    UserStore.Users.Add(new User(article.UserName));
                }

                ArticleStore.Articles.Add(article);
            }
        }
    }
}