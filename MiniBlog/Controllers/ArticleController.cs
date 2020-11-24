using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniBlog.Model;
using MiniBlog.Service;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService articleService;
        private readonly UserService userService;

        public ArticleController(ArticleService articleService, UserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return this.articleService.GetAll();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            this.articleService.AddArticle(article);
            this.userService.Register(new User(article.UserName));

            return CreatedAtAction(nameof(GetByTitle), new { id = article.Id }, article);
        }

        [HttpGet("{id}")]
        public Article GetByTitle(Guid id)
        {
            return this.articleService.GetById(id);
        }
    }
}