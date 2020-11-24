using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public List<Article> List()
        {
            return ArticleStoreWhichWillReplaceInFuture.Articles.ToList();
        }

        [HttpPost]
        public Article Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!UserStoreWhichWillReplaceInFuture.Users.Exists(_ => article.UserName == _.Name))
                {
                    UserStoreWhichWillReplaceInFuture.Users.Add(new User(article.UserName));
                }

                ArticleStoreWhichWillReplaceInFuture.Articles.Add(article);
            }

            return article;
        }

        [HttpGet("{id}")]
        public Article GetByTitle(Guid id)
        {
            var foundArticle = ArticleStoreWhichWillReplaceInFuture.Articles.FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}